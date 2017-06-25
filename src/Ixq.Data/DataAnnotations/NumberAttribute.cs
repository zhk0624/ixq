﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Core.Data;
using Ixq.Core.Entity;

namespace Ixq.Data.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NumberAttribute : Attribute , IDataAnnotations
    {
        /// <summary>
        ///     获取或设置步长，默认：0.01。
        /// </summary>
        public double Step { get; set; } = 0.01;
        /// <summary>
        ///     获取或设置最大值。
        /// </summary>
        public long Max { get; set; }
        /// <summary>
        ///     获取或设置最小值。
        /// </summary>
        public long Min { get; set; }

        public void SetRuntimeProperty(IEntityPropertyMetadata runtimeProperty)
        {
            if (runtimeProperty == null)
                throw new ArgumentNullException(nameof(runtimeProperty));

            runtimeProperty.Step = this.Step;
            runtimeProperty.Max = this.Max;
            runtimeProperty.Min = this.Min;
        }
    }
}
