#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
#endregion

namespace Blazorise.Base
{
    public abstract class BaseBadge : BaseComponent
    {
        #region Members

        private bool isPill;

        private Variant variant = Variant.None;

        private string link;

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add( () => ClassProvider.Badge() )
                .If( () => ClassProvider.BadgeColor( Variant ), () => Variant != Variant.None )
                .If( () => ClassProvider.BadgePill(), () => IsPill );

            base.RegisterClasses();
        }

        #endregion

        #region Properties

        [Parameter]
        protected bool IsPill
        {
            get => isPill;
            set
            {
                isPill = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter]
        protected Variant Variant
        {
            get => variant;
            set
            {
                variant = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter]
        protected string Link
        {
            get => link;
            set
            {
                link = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter] protected RenderFragment ChildContent { get; set; }

        #endregion
    }
}
