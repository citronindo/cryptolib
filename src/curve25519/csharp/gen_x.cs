﻿using System;
using curve25519_dotnet.csharp;

namespace citronindo.cryptolib.curve25519.csharp
{
    public class Gen_x
    {
        public static int convert_25519_pubkey(byte[] ed_pubkey_bytes, byte[] x25519_pubkey_bytes)
        {
            int[] u = new int[10];
            int[] y = new int[10];

            /* Convert the X25519 public key into an Ed25519 public key.
             
               y = (u - 1) / (u + 1)

               NOTE: u=-1 is converted to y=0 since fe_invert is mod-exp
            */
            if (!Fe_isreduced.fe_isreduced(x25519_pubkey_bytes))
                return -1;
            Fe_frombytes.fe_frombytes(u, x25519_pubkey_bytes);
            Fe_montx_to_edy.fe_montx_to_edy(y, u);
            Fe_tobytes.fe_tobytes(ed_pubkey_bytes, y);
            return 0;
        }

        public static int calculate_25519_keypair(byte[] K_bytes, byte[] k_scalar,
            byte[] x25519_privkey_scalar)
        {
            byte[] kneg = new byte[Gen_constants.SCALARLEN];
            Ge_p3 ed_pubkey_point = new Ge_p3();
            byte sign_bit = 0;

            //if (Gen_constants.SCALARLEN != 32)
            //    return -1;

            /* Convert the Curve25519 privkey to an Ed25519 public key */
            Ge_scalarmult_base.ge_scalarmult_base(ed_pubkey_point, x25519_privkey_scalar);
            Ge_p3_tobytes.ge_p3_tobytes(K_bytes, ed_pubkey_point);

            /* Force Edwards sign bit to zero */
            sign_bit = (byte)((K_bytes[31] & 0x80) >> 7);
            Array.Copy(x25519_privkey_scalar, 0, k_scalar, 0, 32);
            Sc_neg.sc_neg(kneg, k_scalar);
            Sc_cmov.sc_cmov(k_scalar, kneg, sign_bit);
            K_bytes[31] &= 0x7F;

            Zeroize.zeroize(kneg, (int)Gen_constants.SCALARLEN);
            return 0;
        }

        public static int generalized_xeddsa_25519_sign(ISha512 sha512provider, byte[] signature_out,
            byte[] x25519_privkey_scalar,
            byte[] msg, uint msg_len,
            byte[] random,
            byte[] customization_label,
            uint customization_label_len)
        {
            byte[] K_bytes = new byte[Gen_constants.POINTLEN];
            byte[] k_scalar = new byte[Gen_constants.SCALARLEN];
            int retval = -1;

            if (calculate_25519_keypair(K_bytes, k_scalar, x25519_privkey_scalar) != 0)
                return -1;

            retval = Gen_eddsa.generalized_eddsa_25519_sign(sha512provider, signature_out,
                K_bytes, k_scalar,
                msg, msg_len, random,
                customization_label, customization_label_len);
            Zeroize.zeroize(k_scalar, (int)Gen_constants.SCALARLEN);
            return retval;
        }

        public static int generalized_xveddsa_25519_sign(
            ISha512 sha512provider,
            byte[] signature_out,
            byte[] x25519_privkey_scalar,
            byte[] msg,
            uint msg_len,
            byte[] random,
            byte[] customization_label,
            uint customization_label_len)
        {
            byte[] K_bytes = new byte[Gen_constants.POINTLEN];
            byte[] k_scalar = new byte[Gen_constants.SCALARLEN];
            int retval = -1;

            if (calculate_25519_keypair(K_bytes, k_scalar, x25519_privkey_scalar) != 0)
                return -1;

            retval = Gen_veddsa.generalized_veddsa_25519_sign(sha512provider, signature_out, K_bytes, k_scalar,
                msg, msg_len, random,
                customization_label, customization_label_len);
            Zeroize.zeroize(k_scalar, (int)Gen_constants.SCALARLEN);
            return retval;
        }

        public static int generalized_xeddsa_25519_verify(
            ISha512 sha512provider,
            byte[] signature,
            byte[] x25519_pubkey_bytes,
            byte[] msg,
            uint msg_len,
            byte[] customization_label,
            uint customization_label_len)
        {
            byte[] K_bytes = new byte[Gen_constants.POINTLEN];

            if (convert_25519_pubkey(K_bytes, x25519_pubkey_bytes) != 0)
                return -1;

            return Gen_eddsa.generalized_eddsa_25519_verify(sha512provider, signature, K_bytes, msg, msg_len,
                customization_label, customization_label_len);
        }

        public static int generalized_xveddsa_25519_verify(
            ISha512 sha512provider,
            byte[] vrf_out,
            byte[] signature,
            byte[] x25519_pubkey_bytes,
            byte[] msg,
            uint msg_len,
            byte[] customization_label,
            uint customization_label_len)
        {
            byte[] K_bytes = new byte[Gen_constants.POINTLEN];

            if (convert_25519_pubkey(K_bytes, x25519_pubkey_bytes) != 0)
                return -1;

            return Gen_veddsa.generalized_veddsa_25519_verify(sha512provider, vrf_out, signature, K_bytes, msg, msg_len,
                customization_label, customization_label_len);
        }

    }
}
