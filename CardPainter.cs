/* CardPainter.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Ksu.Cis300.Klondike
{
    /// <summary>
    /// Contains contants and static methods/properties for drawing cards.
    /// </summary>
    public static class CardPainter
    {
        /// <summary>
        /// The height of a single card image from the input files.
        /// </summary>
        private const int _cardImageHeight = 333;

        /// <summary>
        /// The width of a single card image from the input files.
        /// </summary>
        private const int _cardImageWidth = 234;

        /// <summary>
        /// The pen used to draw the box where the stock will be placed.
        /// </summary>
        private static Pen _boxPen = new Pen(Color.White);

        /// <summary>
        /// The height of a displayed card drawing.
        /// </summary>
        public const int CardHeight = _cardImageHeight / 3;

        /// <summary>
        /// The width of a displayed card drawing.
        /// </summary>
        public const int CardWidth = _cardImageWidth / 3;

        /// <summary>
        /// The image file name prefixes of each of the four suits.
        /// </summary>
        public static string[] FilePrefixes { get; } = 
            { "clubs_", "diamonds_", "hearts_", "spades_" };

        /// <summary>
        /// The name of the directory containing the images.
        /// </summary>
        public const string Directory = "../../images/";

        /// <summary>
        /// The image file name suffix.
        /// </summary>
        public const string FileSuffix = ".png";

        /// <summary>
        /// Gets the back of a card.
        /// </summary>
        public static Image CardBack { get; } = Image.FromFile(Directory + "back" + FileSuffix);

        /// <summary>
        /// Gets the pen used to highlight selected cards.
        /// </summary>
        public static Pen HighlightPen { get; } = new Pen(Color.Magenta, 2);

        /// <summary>
        /// Draws the back of a card on the given graphics context at the given location.
        /// </summary>
        /// <param name="g">The graphics context on which to draw.</param>
        /// <param name="x">The x-coordinate of the upper-left corner.</param>
        /// <param name="y">The y-coordinate of the upper-left corner.</param>
        public static void DrawBack(Graphics g, int x, int y)
        {
            g.DrawImage(CardBack, x, y, CardWidth, CardHeight);
        }

        /// <summary>
        /// Draws the given card on the given graphics context at the given location.
        /// </summary>
        /// <param name="c">The card to draw.</param>
        /// <param name="g">The graphics context on which to draw.</param>
        /// <param name="x">The x-coordinate of the upper-left corner.</param>
        /// <param name="y">The y-coordinate of the upper-left corner.</param>
        public static void DrawCard(Card c, Graphics g, int x, int y)
        {
            g.DrawImage(c.Picture, x, y, CardWidth, CardHeight);
        }

        /// <summary>
        /// Draws a box the size of a card at the given location on the given graphics context.
        /// </summary>
        /// <param name="g">The graphics context on which to draw.</param>
        /// <param name="x">The x-coordinate of the upper-left corner.</param>
        /// <param name="y">The y-coordinate of the upper-left corner.</param>
        public static void DrawBox(Graphics g, int x, int y)
        {
            g.DrawRectangle(_boxPen, x, y, CardWidth, CardHeight);
        }
    }
}
