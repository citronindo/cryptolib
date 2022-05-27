using citronindo.crypto.curve25519;

namespace citronindo.crypto.digest
{

    public class Curve_sigs
    {
        public static int Curve_sign(ISha512 sha512provider, byte[] signature_out,
                            byte[] Curve_privkey,
                            byte[] msg, int msg_len,
                            byte[] random)
        {
            Ge_p3 ed_pubkey_point = new Ge_p3(); /* Ed25519 pubkey point */
            byte[] ed_pubkey = new byte[32]; /* Ed25519 encoded pubkey */
            byte[] sigbuf = new byte[msg_len + 128]; /* working buffer */
            byte sign_bit = 0;

            /* Convert the Curve privkey to an Ed25519 public key */
            Ge_scalarmult_base.ge_scalarmult_base(ed_pubkey_point, Curve_privkey);
            Ge_p3_tobytes.ge_p3_tobytes(ed_pubkey, ed_pubkey_point);
            sign_bit = (byte)(ed_pubkey[31] & 0x80);

            /* Perform an Ed25519 signature with explicit private key */
            sign_modified.crypto_sign_modified(sha512provider, sigbuf, msg, msg_len, Curve_privkey,
                                               ed_pubkey, random);
            Array.Copy(sigbuf, 0, signature_out, 0, 64);

            /* Encode the sign bit into signature (in unused high bit of S) */
            signature_out[63] &= 0x7F; /* bit should be zero already, but just in case */
            signature_out[63] |= sign_bit;
            return 0;
        }

        public static int Curve_verify(ISha512? sha512provider, byte[] signature,
                              byte[] Curve_pubkey,
                              byte[] msg, int msg_len)
        {
            int[] u = new int[10];
            int[] y = new int[10];
            byte[] ed_pubkey = new byte[32];
            byte[] verifybuf = new byte[msg_len + 64]; /* working buffer */
            byte[] verifybuf2 = new byte[msg_len + 64]; /* working buffer #2 */

            /* Convert the Curve public key into an Ed25519 public key.  In
               particular, convert Curve's "montgomery" x-coordinate (u) into an
               Ed25519 "edwards" y-coordinate:

               y = (u - 1) / (u + 1)

               NOTE: u=-1 is converted to y=0 since fe_invert is mod-exp

               Then move the sign bit into the pubkey from the signature.
            */
            Fe_frombytes.fe_frombytes(u, Curve_pubkey);
            Fe_montx_to_edy.fe_montx_to_edy(y, u);
            Fe_tobytes.fe_tobytes(ed_pubkey, y);

            /* Copy the sign bit, and remove it from signature */
            ed_pubkey[31] &= 0x7F;  /* bit should be zero already, but just in case */
            ed_pubkey[31] |= (byte)(signature[63] & 0x80);
            Array.Copy(signature, 0, verifybuf, 0, 64);
            verifybuf[63] &= 0x7F;

            Array.Copy(msg, 0, verifybuf, 64, (int)msg_len);

            /* Then perform a normal Ed25519 verification, return 0 on success */
            /* The below call has a strange API: */
            /* verifybuf = R || S || message */
            /* verifybuf2 = java to next call gets a copy of verifybuf, S gets
               replaced with pubkey for hashing, then the whole thing gets zeroized
               (if bad sig), or contains a copy of msg (good sig) */
            return open_modified.crypto_sign_open_modified(sha512provider, verifybuf2, verifybuf, 64 + msg_len, ed_pubkey);
        }
    }
}
