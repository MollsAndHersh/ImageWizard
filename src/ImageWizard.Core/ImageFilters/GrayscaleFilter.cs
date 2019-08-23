﻿using ImageWizard.Core.ImageFilters.Base.Attributes;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageWizard.Filters
{
    public class GrayscaleFilter : FilterBase
    {
        [Filter]
        public void Grayscale(FilterContext context)
        {
            context.Image.Mutate(m => m.Grayscale());
        }

        [Filter]
        public void Grayscale(float amount, FilterContext context)
        {
            context.Image.Mutate(m => m.Grayscale(amount));
        }
    }
}
