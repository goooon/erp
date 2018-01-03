namespace CenterLib
{
    using System;
    using System.Data;
    using System.IO;
    using System.IO.Compression;
    using System.Runtime.Serialization.Formatters.Binary;

    internal class DataSetCompression
    {
        private DataSetCompression()
        {
        }

        public static byte[] CompressionDataSet(DataSet dsOriginal)
        {
            dsOriginal.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bFormatter = new BinaryFormatter();
            MemoryStream mStream = new MemoryStream();
            bFormatter.Serialize(mStream, dsOriginal);
            byte[] bytes = mStream.ToArray();
            MemoryStream oStream = new MemoryStream();
            DeflateStream zipStream = new DeflateStream(oStream, CompressionMode.Compress);
            zipStream.Write(bytes, 0, bytes.Length);
            zipStream.Flush();
            zipStream.Close();
            return oStream.ToArray();
        }

        public static DataSet DecompressionDataSet(byte[] bytes)
        {
            MemoryStream mStream = new MemoryStream(bytes);
            mStream.Seek(0, SeekOrigin.Begin);
            DeflateStream unZipStream = new DeflateStream(mStream, CompressionMode.Decompress, true);
            DataSet dsResult = new DataSet {
                RemotingFormat = SerializationFormat.Binary
            };
            BinaryFormatter bFormatter = new BinaryFormatter();
            return (DataSet) bFormatter.Deserialize(unZipStream);
        }
    }
}

