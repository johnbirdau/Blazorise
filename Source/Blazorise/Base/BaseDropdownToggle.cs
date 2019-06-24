﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
#endregion

namespace Blazorise.Base
{
    public abstract class BaseDropdownToggle : BaseComponent, ICloseActivator, IDisposable
    {
        #region Members

        private bool isOpen;

        private bool isSplit;

        private bool isRegistered;

        #endregion

        #region Methods

        public void Dispose()
        {
            // make sure to unregister listener
            if ( isRegistered )
            {
                isRegistered = false;

                JSRunner.UnregisterClosableComponent( this );
            }
        }

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add( () => ClassProvider.DropdownToggle() )
                .If( () => ClassProvider.DropdownToggleColor( Variant ), () => Variant != Variant.None && !IsOutline )
                .If( () => ClassProvider.DropdownToggleOutline( Variant ), () => Variant != Variant.None && IsOutline )
                .If( () => ClassProvider.DropdownToggleSize( Size ), () => Size != ButtonSize.None )
                .If( () => ClassProvider.DropdownToggleSplit(), () => IsSplit );

            base.RegisterClasses();
        }

        protected override void OnInit()
        {
            // link to the parent component
            Dropdown?.Hook( this );

            base.OnInit();
        }

        protected void ClickHandler()
        {
            Dropdown?.Toggle();
        }

        public bool SafeToClose( string elementId, bool isEscapeKey )
        {
            return isEscapeKey || elementId != ElementId;
        }

        public void Close()
        {
            Dropdown?.Close();
        }

        #endregion

        #region Properties

        protected bool IsGroup => Dropdown?.IsGroup == true;

        /// <summary>
        /// Gets or sets the dropdown color.
        /// </summary>
        [Parameter] protected Variant Variant { get; set; } = Variant.None;

        /// <summary>
        /// Gets or sets the dropdown size.
        /// </summary>
        [Parameter] protected ButtonSize Size { get; set; } = ButtonSize.None;

        /// <summary>
        /// Handles the visibility of dropdown toggle.
        /// </summary>
        [Parameter]
        internal bool IsOpen
        {
            get => isOpen;
            set
            {
                isOpen = value;

                if ( isOpen )
                {
                    isRegistered = true;

                    JSRunner.RegisterClosableComponent( this );
                }
                else
                {
                    isRegistered = false;

                    JSRunner.UnregisterClosableComponent( this );
                }

                ClassMapper.Dirty();
            }
        }

        /// <summary>
        /// Button outline.
        /// </summary>
        [Parameter] protected bool IsOutline { get; set; }

        /// <summary>
        /// Handles the visibility of split button.
        /// </summary>
        [Parameter]
        protected bool IsSplit
        {
            get => isSplit;
            set
            {
                isSplit = value;

                ClassMapper.Dirty();
            }
        }

        [CascadingParameter] protected BaseDropdown Dropdown { get; set; }

        [Parameter] protected RenderFragment ChildContent { get; set; }

        #endregion
    }
}
