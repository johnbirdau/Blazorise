#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise.Utils;
using Microsoft.AspNetCore.Components;
#endregion

namespace Blazorise.Base
{
    public abstract class BaseTableRowCell : BaseComponent
    {
        #region Members

        private Variant variant = Variant.None;

        private Background background = Background.None;

        private TextVariant textVariant = TextVariant.None;

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add( () => ClassProvider.TableRowCell() )
                .If( () => ClassProvider.TableRowCellColor( Variant ), () => Variant != Variant.None )
                .If( () => ClassProvider.TableRowCellBackground( Background ), () => Background != Background.None )
                .If( () => ClassProvider.TableRowCellTextColor( TextVariant ), () => TextVariant != TextVariant.None );

            base.RegisterClasses();
        }

        protected void HandleClick( UIMouseEventArgs e )
        {
            Clicked.InvokeAsync( EventArgsMapper.ToMouseEventArgs( e ) );
        }

        #endregion

        #region Properties

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
        protected Background Background
        {
            get => background;
            set
            {
                background = value;

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

        /// <summary>
        /// Occurs when the row cell is clicked.
        /// </summary>
        [Parameter] protected EventCallback<MouseEventArgs> Clicked { get; set; }

        [Parameter] protected RenderFragment ChildContent { get; set; }

        #endregion
    }
}
