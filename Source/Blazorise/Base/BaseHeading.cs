#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
#endregion

namespace Blazorise.Base
{
    public abstract class BaseHeading : BaseComponent
    {
        #region Members

        private HeadingSize headingSize = HeadingSize.Is3;

        private TextVariant textVariant = TextVariant.None;

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add( () => ClassProvider.Heading( headingSize ) )
                .If( () => ClassProvider.HeadingTextColor( TextVariant ), () => TextVariant != TextVariant.None );

            base.RegisterClasses();
        }

        #endregion

        #region Properties

        [Parameter]
        protected HeadingSize Size
        {
            get => headingSize;
            set
            {
                headingSize = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter]
        protected TextVariant TextVariant
        {
            get => textVariant;
            set
            {
                textVariant = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter] protected RenderFragment ChildContent { get; set; }

        #endregion
    }
}
