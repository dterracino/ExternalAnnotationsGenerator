﻿using System;
using System.Collections.Generic;
using ExternalAnnotationsGenerator.Core.Construction;
using ExternalAnnotationsGenerator.Core.Model;
using JetBrains.Annotations;

namespace ExternalAnnotationsGenerator.Core
{
    public static class CoreHelper
    {
        /// <summary>
        /// Get the annotations generated by the fluent builder hidden behind the public interface.
        /// </summary>
        public static IEnumerable<AssemblyAnnotations> GetAnnotations([NotNull] IAnnotator annotator)
        {
            return GetBuilder(annotator).GetAnnotations();
        }

        /// <summary>
        /// Get the annotations builder hidden behind the public interface.
        /// </summary>
        public static AnnotationsBuilder GetBuilder([NotNull] IAnnotator annotator)
        {
            if (annotator == null) throw new ArgumentNullException(nameof(annotator));
            var builder = annotator as AnnotationsBuilder;
            if (builder == null) throw new ArgumentException("Expected a builder", nameof(annotator));
            return builder;
        }
    }
}