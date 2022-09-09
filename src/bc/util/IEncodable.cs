using System.IO;

namespace citronindo.cryptolib.bc.Utilities
{
    public interface IEncodable
    {
        ///<summary>
        ///
        ///
        ///
        ///
        /// 
         // * Return a byte array representing the implementing object.
         // *
         // * @return a byte array representing the encoding.
         // * @throws IOException if an issue arises generation the encoding.
         // */
        byte[] GetEncoded();
    }
}