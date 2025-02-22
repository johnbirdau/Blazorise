﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
#endregion

namespace Blazorise.Base
{
    public abstract class BaseTableHeader : BaseComponent
    {
        #region Members

        private Theme theme;

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add( () => ClassProvider.TableHeader() )
                .If( () => ClassProvider.TableHeaderTheme( Theme ), () => Theme != Theme.None );

            base.RegisterClasses();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets the background color to the header.
        /// </summary>
        [Parameter]
        protected Theme Theme
        {
            get => theme;
            set
            {
                theme = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter] protected RenderFragment ChildContent { get; set; }

        #endregion
    }
}
