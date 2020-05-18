﻿using ImageWizard.Core.ImageFilters.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageWizard.SkiaSharp.Filters.Base
{
    public class SkiaSharpFilter : Filter<SkiaSharpFilterContext>
    {
        public override string Namespace => "skiasharp";
    }
}
