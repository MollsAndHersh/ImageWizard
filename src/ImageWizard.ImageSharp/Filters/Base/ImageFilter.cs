﻿using ImageWizard.Core.ImageFilters.Base;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageWizard.ImageSharp.Filters
{
    public abstract class ImageFilter : Filter<ImageFilterContext>
    {
        public ImageFilter()
        {

        }
    }
}
