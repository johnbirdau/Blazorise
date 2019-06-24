#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
#endregion

namespace Blazorise.Base
{
    public abstract class BaseAlert : BaseComponent
    {
        #region Members

        private bool isDismisable;

        private bool isShow;

        private Variant variant = Variant.None;

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add( () => ClassProvider.Alert() )
                .If( () => ClassProvider.AlertColor( Variant ), () => Variant != Variant.None )
                .If( () => ClassProvider.AlertDismisable(), () => IsDismisable )
                .If( () => ClassProvider.Fade(), () => IsDismisable )
                .If( () => ClassProvider.Show(), () => IsDismisable && IsShow );

            base.RegisterClasses();
        }

        public void Show()
        {
            IsShow = true;
            StateHasChanged();
        }

        public void Hide()
        {
            IsShow = false;
            StateHasChanged();
        }

        public void Toggle()
        {
            IsShow = !IsShow;
            StateHasChanged();
        }

        #endregion

        #region Properties

        [Parameter]
        protected bool IsDismisable
        {
            get => isDismisable;
            set
            {
                isDismisable = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter]
        protected bool IsShow
        {
            get => isShow;
            set
            {
                isShow = value;

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

        [Parameter] protected RenderFragment ChildContent { get; set; }

        #endregion
    }
}
