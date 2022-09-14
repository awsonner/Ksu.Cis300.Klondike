/* CardPile.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.Klondike
{
    /// <summary>
    /// A control containing a pile of cards.
    /// </summary>
    public partial class CardPile : UserControl
    {
        /// <summary>
        /// Gets the pile of cards.
        /// </summary>
        public Stack<Card> Pile { get; } = new Stack<Card>();

        /// <summary>
        /// Gets or sets whether the top card is shown face up.
        /// </summary>
        public bool IsFaceUp { get; set; }

        /// <summary>
        /// Initializes the control.
        /// </summary>
        public CardPile()
        {
            InitializeComponent();
            Width = CardPainter.CardWidth + 1;
            Height = CardPainter.CardHeight + 1;
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        /// <param name="e">The data for the object on which to paint.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // This method redefines the OnPaint method defined within the UserControl class,
            // which is the super-type (or parent) of this class. The following line ensures
            // that everything done by the overridden method is done here.
            base.OnPaint(e);

            Graphics g = e.Graphics;
            CardPainter.DrawBox(g, 0, 0);
            if (Pile.Count > 0)
            {
                if (IsFaceUp)
                {
                    CardPainter.DrawCard(Pile.Peek(), g, 0, 0);
                }
                else
                {
                    CardPainter.DrawBack(g, 0, 0);
                }
            }
        }
    }
}
