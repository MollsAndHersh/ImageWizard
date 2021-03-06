﻿using ImageWizard.Core.ImageFilters.Base.Attributes;
using ImageWizard.ImageFormats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageWizard.ImageSharp.Filters
{
    public class ImageFormatFilter : ImageSharpFilter
    {
        [Filter]
        public void Bmp()
        {
            Context.ImageFormat = new BmpFormat();
        }

        [Filter]
        public void Gif()
        {
            Context.ImageFormat = new GifFormat();
        }

        [Filter]
        public void Jpg()
        {
            Context.ImageFormat = new JpegFormat();
        }

        [Filter]
        public void Jpg(int quality)
        {
            Context.ImageFormat = new JpegFormat() { Quality = quality };
        }

        [Filter]
        public void Png()
        {
            Context.ImageFormat = new PngFormat();
        }
    }
}
