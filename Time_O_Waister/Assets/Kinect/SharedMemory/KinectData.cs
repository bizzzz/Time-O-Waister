using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace KinectData
{
    struct Image
    {
        public enum Format : byte
        {
            UNKNOWN = 0,
            RGBA32,
            BGRA32,
            RGB24,
            BGR24
        }

        // Header = Image-meta-data
        private byte[] header;

        public Int32 frameNumber
        {
            get { return BitConverter.ToInt32(header, 0); }
            set { Array.Copy(BitConverter.GetBytes(value),0, header,
                0, 
                sizeof(Int32));
            }
        }
        public Int64 timeStamp
        {
            get { return BitConverter.ToInt64(header, sizeof(Int32)); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header,
                sizeof(Int32),
                sizeof(Int64)); 
            }
        }
        public Int32 width
        {
            get { return BitConverter.ToInt32(header, sizeof(Int32) + sizeof(Int64)); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header,
                sizeof(Int32) + sizeof(Int64),
                sizeof(Int32)); }
        }
        public Int32 height
        {
            get { return BitConverter.ToInt32(header, sizeof(Int32) + sizeof(Int64) + sizeof(Int32)); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header,
                sizeof(Int32) + sizeof(Int64) + sizeof(Int32),
                sizeof(Int32)); 
            }
        }
        public Int32 bytesPerPixel
        {
            get { return BitConverter.ToInt32(header, sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32)); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header,
                sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32),
                sizeof(Int32));
            }
        }
        public Int32 imageLength
        {
            get { return (width * height * bytesPerPixel); }
            /*set { Array.Copy(BitConverter.GetBytes(value), 0, header,
                sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32),
                sizeof(Int32)); }
              */
        }
        public Format format
        {
            get { return (Format)header[sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32)]; }
            set { header[sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32)] = (byte)value; }
        }
        private byte reserved1
        {
            get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(byte)]; }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header,
                sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(byte),
                sizeof(byte));
            }
        }
        private byte reserved2
        {
            get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(byte) + sizeof(byte)]; }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header,
                sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32)  + sizeof(byte) + sizeof(byte),
                sizeof(byte)); 
            }
        }
        private byte reserved3
        {
            get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(byte) + sizeof(byte) + sizeof(byte)]; }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header, 
                sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(byte) + sizeof(byte) + sizeof(byte),
                sizeof(byte));
            }
        }
        public Int32 metadataLength
        {
            get { return header.Length; }
        }
        public byte[] metadata
        {
            get { return header; }
        }

        // Payload = Image
        private byte[] payload;

        public byte[] image
        {
            get { return payload; }
        }

        /// <summary>
        /// Constructor.
        /// A general image which shall be rendered to shared memory.
        /// </summary>
        /// <param name="width">
        /// The width in pixels.
        /// </param>
        /// <param name="height">
        /// The height in pixels.
        /// </param>
        /// <param name="bytesPerPixel">
        /// The bytes per pixel.
        /// </param>
        /// <param name="format">
        /// The format in which the image will be put into shared memory.
        /// </param>
        public Image(Int32 width, Int32 height, Int32 bytesPerPixel, Format format)
        {
            // initialize payload
            this.payload = new byte[width * height * bytesPerPixel];
            // initialize header
            this.header = new byte[sizeof(Int32) /*frameNumber*/ + sizeof(Int64) /*timeStamp*/ +
                sizeof(Int32) /*width*/ + sizeof(Int32) /*height*/ + sizeof(Int32) /*bpp*/ + sizeof(byte) /*format*/ + 
                sizeof(byte) /*reserved1*/ + sizeof(byte) /*reserved2*/+ sizeof(byte) /*reserved3*/];
            
            this.width = width;
            this.height = height;
            this.bytesPerPixel = bytesPerPixel;
            this.format = format;
            this.frameNumber = -1;
            this.timeStamp = 0;
            this.reserved1 = 88;
            this.reserved2 = 99;
            this.reserved3 = 22;
        }

        /// <summary>
        /// Constructor #2.
        /// </summary>
        /// <param name="format">
        /// The format in which the image will be put into shared memory.
        /// </param>
        public Image(Format format)
        {
            // initialize payload
            this.payload = new byte[0];
            // initialize header
            this.header = new byte[sizeof(Int32) /*frameNumber*/ + sizeof(Int64) /*timeStamp*/ +
                sizeof(Int32) /*width*/ + sizeof(Int32) /*height*/ + sizeof(Int32) /*bpp*/ + sizeof(byte) /*format*/ +
                sizeof(byte) /*reserved1*/ + sizeof(byte) /*reserved2*/+ sizeof(byte) /*reserved3*/];
 
            this.width = 0;
            this.height = 0;
            this.bytesPerPixel = 0;
            this.format = format;
            this.frameNumber = -1;
            this.timeStamp = 0;
            //this.reserved1 = 0;
            //this.reserved2 = 0;
            //this.reserved3 = 0;
        }

    } // END struct Image


    struct DepthImage
    {
        public enum Format : byte
        {
            UNKNOWN = 0,
            RGBA32,
            BGRA32,
            RGB24,
            BGR24
        }

        // Header = Image-meta-data
        private byte[] header;


        public Int32 frameNumber
        {
            get { return BitConverter.ToInt32(header, 0); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header, 0, sizeof(Int32)); }
        }
        public Int64 timeStamp
        {
            get { return BitConverter.ToInt64(header, sizeof(Int32)); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header, sizeof(Int32), sizeof(Int64)); }
        }
        public Int32 width
        {
            get { return BitConverter.ToInt32(header, sizeof(Int32) + sizeof(Int64)); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header, sizeof(Int32) + sizeof(Int64), sizeof(Int32)); }
        }
        public Int32 height
        {
            get { return BitConverter.ToInt32(header, sizeof(Int32) + sizeof(Int64) + sizeof(Int32)); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header, sizeof(Int32) + sizeof(Int64) + sizeof(Int32), sizeof(Int32)); }
        }
        public Int32 bytesPerPixel
        {
            get { return BitConverter.ToInt32(header, sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32)); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header, sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32), sizeof(Int32)); }
        }
        public Int32 imageLength
        {
            get { return (width * height * bytesPerPixel); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header, sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32), sizeof(Int32)); }
        }
        public Format format
        {
            get { return (Format)header[sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32)]; }
            set { header[sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32)] = (byte)value; }
        }
        private byte reserved1
        {
            get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(byte)]; }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header, sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(byte), sizeof(byte)); }
        }
        private byte reserved2
        {
            get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(byte) + sizeof(byte)]; }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header, sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(byte) + sizeof(byte), sizeof(byte)); }
        }
        private byte reserved3
        {
            get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(byte) + sizeof(byte) + sizeof(byte)]; }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header, sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(byte) + sizeof(byte) + sizeof(byte), sizeof(byte)); }
        }
        public Int32 metadataLength
        {
            get { return header.Length; }
        }
        public byte[] metadata
        {
            get { return header; }
        }

        // Payload = Image
        private short[] payload;

        public short[] image
        {
            get { return payload; }
        }

        public DepthImage(Int32 width, Int32 height, Int32 bytesPerPixel, Format format)
        {
            // initialize payload
            this.payload = new short[width * height];
            // initialize header
            this.header = new byte[sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte)];
            this.width = width;
            this.height = height;
            this.bytesPerPixel = bytesPerPixel;
            this.format = format;
            this.frameNumber = -1;
            this.timeStamp = 0;
            //this.reserved1 = 0;
            //this.reserved2 = 0;
            //this.reserved3 = 0;
        }

        public DepthImage(Format format)
        {
            // initialize payload
            this.payload = new short[0];
            // initialize header
            this.header = new byte[sizeof(Int32) + sizeof(Int64) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(Int32) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte)];
            this.width = 0;
            this.height = 0;
            this.bytesPerPixel = 0;
            this.format = format;
            this.frameNumber = -1;
            this.timeStamp = 0;
            //this.reserved1 = 0;
            //this.reserved2 = 0;
            //this.reserved3 = 0;
        }

        public byte[] getByteImage()
        {
            byte[] byteImage = new byte[this.image.Length * 2];
            Buffer.BlockCopy(this.image, 0, byteImage, 0, byteImage.Length);
            return byteImage;
        }
    }

    struct Skeletons
    {
        public enum JointTrackingState : byte
        {
            //joint is not tracked
            NOTTRACKED = 0,
            //joint is tracked but not trusty
            INFERRED,
            //joint is trustly tracked
            TRACKED
        }

        public enum SkeletonTrackingState : byte
        {
            //Skeleton tracked as passive User(only gravity point)
            PASSIVE = 0,
            //Skeleton is tracked as active user
            ACTIVE,
            //Skeleton is not available
            NOTTRACKING
        }

        public enum SkeletonTrackingMode : byte
        {
            //Skeleton tracked as passive User(only gravity point)
            DEFAULT = 0,
            //Skeleton is tracked as active user
            SEATED
        }

        // Header = Image-meta-data
        private byte[] header;

        public Int32 frameNumber
        {
            get { return BitConverter.ToInt32(header, 0); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header, 0, sizeof(Int32)); }
        }
        public Int64 timeStamp
        {
            get { return BitConverter.ToInt64(header, sizeof(Int32)); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header, sizeof(Int32), sizeof(Int64)); }
        }
        public byte trackingMode
        {
            get { return header[sizeof(Int32) + sizeof(Int64)]; }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header, sizeof(Int32) + sizeof(Int64), sizeof(byte)); }
        }
        public byte nrTrackedSkeletons
        {
            get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(byte)]; }
            set { Array.Copy(BitConverter.GetBytes(value), 0, header, sizeof(Int32) + sizeof(Int64) + sizeof(byte), sizeof(byte)); }
        }
        public float floorClipPlaneX
        {
            get { return BitConverter.ToSingle(this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte)); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte), sizeof(float)); }
        }
        public float floorClipPlaneY
        {
            get { return BitConverter.ToSingle(this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float)); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float), sizeof(float)); }
        }
        public float floorClipPlaneZ
        {
            get { return BitConverter.ToSingle(this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float)); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float), sizeof(float)); }
        }
        public float floorClipPlaneW
        {
            get { return BitConverter.ToSingle(this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float)); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float), sizeof(float)); }
        }
        private byte reserved1
        {
            get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float)]; }
            set { Array.Copy(BitConverter.GetBytes(value), 0, this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float), sizeof(byte)); }
        }
        private byte reserved2
        {
            get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float)+ sizeof(byte) ]; }
            set { Array.Copy(BitConverter.GetBytes(value), 0, this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(byte), sizeof(byte)); }
        }
        //private byte reserved3
        //{
        //    get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float)]; }
        //    set { Array.Copy(BitConverter.GetBytes(value), 0, this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(byte) + sizeof(byte), sizeof(byte)); }
        //}
        //private byte reserved4
        //{
        //    get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float)]; }
        //    set { Array.Copy(BitConverter.GetBytes(value), 0, this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(byte) + sizeof(byte) + sizeof(byte), sizeof(byte)); }
        //}
        //private byte reserved5
        //{
        //    get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float)]; }
        //    set { Array.Copy(BitConverter.GetBytes(value), 0, this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte), sizeof(byte)); }
        //}
        //private byte reserved6
        //{
        //    get { return header[sizeof(Int32) + sizeof(Int64) + +sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float)]; }
        //    set { Array.Copy(BitConverter.GetBytes(value), 0, this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte), sizeof(byte)); }
        //}
        //private byte reserved7
        //{
        //    get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float)]; }
        //    set { Array.Copy(BitConverter.GetBytes(value), 0, this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte), sizeof(byte)); }
        //}
        //private byte reserved8
        //{
        //    get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float)]; }
        //    set { Array.Copy(BitConverter.GetBytes(value), 0, this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte), sizeof(byte)); }
        //}
        //private byte reserved9
        //{
        //    get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float)]; }
        //    set { Array.Copy(BitConverter.GetBytes(value), 0, this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte), sizeof(byte)); }
        //}
        //private byte reserved10
        //{
        //    get { return header[sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float)]; }
        //    set { Array.Copy(BitConverter.GetBytes(value), 0, this.header, sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte), sizeof(byte)); }
        //}
        public Int32 metadataLength
        {
            get { return header.Length; }
        }
        public byte[] metadata
        {
            get { return header; }
        }
        public Int32 skeletonsLength
        {
            get { return 1422; }
        }

        // Payload = Image
        private byte[] payload;

        public byte[] skeletonsBytes
        {
            get { return payload; }
        }

        public Skeletons(byte[] skeletons)
        {
            // initialize payload
            this.payload = new byte[1422];
            this.header = new byte[sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float)+ sizeof(byte) + sizeof(byte) ];
            Array.Copy(skeletons, 0, this.header, 0, this.metadataLength);
            Array.Copy(skeletons, this.metadataLength, this.payload, 0, this.skeletonsLength);
            this.floorClipPlaneZ = 0;
            this.floorClipPlaneY = 0;
            this.floorClipPlaneX = 0;
            this.floorClipPlaneW = 0;
            //this.reserved1 = 0;
            //this.reserved2 = 0;
            //this.reserved3 = 0;
        }
        public Skeletons(byte trackedSkeletons)
        {
            // initialize payload
            this.payload = new byte[1422];
            this.header = new byte[sizeof(Int32) + sizeof(Int64) + sizeof(byte) + sizeof(byte) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(float) + sizeof(byte) + sizeof(byte)];
            this.trackingMode = 0;
            this.frameNumber = -1;
            this.timeStamp = 0;
            this.nrTrackedSkeletons = trackedSkeletons;
            this.floorClipPlaneZ = 0;
            this.floorClipPlaneY = 0;
            this.floorClipPlaneX = 0;
            this.floorClipPlaneW = 0;
            //this.reserved1 = 0;
            //this.reserved2 = 0;
            //this.reserved3 = 0;
        }
    }
}
