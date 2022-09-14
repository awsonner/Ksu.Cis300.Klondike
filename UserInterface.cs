/* UserInterface.cs
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
    /// A GUI for a Klondike Solitaire program.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The stock.
        /// </summary>
        private CardPile uxStock = new CardPile();

        /// <summary>
        /// The discard pile.
        /// </summary>
        private DiscardPile uxDiscardPile = new DiscardPile();

        /// <summary>
        /// The foundation piles.
        /// </summary>
        private CardPile[] uxFoundation = new CardPile[4];

        /// <summary>
        /// The tableau columns.
        /// </summary>
        private TableauColumn[] uxTableauColumns = new TableauColumn[7];

        /// <summary>
        /// The game controller.
        /// </summary>
        private Game _game;

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();

            // Add controls and event handlers.

            // uxStockFoundationPanel is a FlowLayoutPanel set to fill from left to right.
            // It will contain the stock, discard pile, and the foundation.
            uxStock.IsFaceUp = false;
            uxStockFoundationPanel.Controls.Add(uxStock);
            uxStock.Click += new EventHandler(uxStock_Click);
            uxStockFoundationPanel.Controls.Add(uxDiscardPile);
            uxDiscardPile.MouseClick += new MouseEventHandler(uxDiscardPile_MouseClick);
            for (int i = 0; i < uxFoundation.Length; i++)
            {
                uxFoundation[i] = new CardPile();
                uxFoundation[i].IsFaceUp = true;
                uxStockFoundationPanel.Controls.Add(uxFoundation[i]);
                uxFoundation[i].MouseClick += new MouseEventHandler(uxFoundation_MouseClick);
            }

            // uxTableauPanel is another FlowLayoutPanel beneath uxStockFoundationPanel.
            // It will contain the tableau.
            for (int i = 0; i < uxTableauColumns.Length; i++)
            {
                uxTableauColumns[i] = new TableauColumn();
                uxTableauPanel.Controls.Add(uxTableauColumns[i]);
                uxTableauColumns[i].MouseClick += new MouseEventHandler(uxTableauColumn_MouseClick);
            }
        }

        /// <summary>
        /// Clears the board.
        /// </summary>
        private void ClearBoard()
        {
            uxStock.Pile.Clear();
            uxDiscardPile.IsSelected = false;
            uxDiscardPile.Pile.Clear();
            for (int i = 0; i < uxFoundation.Length; i++)
            {
                uxFoundation[i].Pile.Clear();
            }
            for (int i = 0; i < uxTableauColumns.Length; i++)
            {
                uxTableauColumns[i].NumberSelected = 0;
                uxTableauColumns[i].FaceDownPile.Clear();
                uxTableauColumns[i].FaceUpPile.Clear();
            }
        }

        /// <summary>
        /// Handles a Click event on the "New Game" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNewGame_Click(object sender, EventArgs e)
        {
            ClearBoard();
            _game = new Game(uxStock, uxTableauColumns, (int)uxSeed.Value);
            uxBoard.Enabled = true;
            Refresh();
        }

        /// <summary>
        /// Handles a Click event on the stock.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxStock_Click(object sender, EventArgs e)
        {
            _game.DrawCardsFromStock(uxStock, uxDiscardPile);
            Refresh();
        }

        /// <summary>
        /// Handles a MouseClick event on the discard pile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Data regarding the mouse click.</param>
        private void uxDiscardPile_MouseClick(object sender, MouseEventArgs e)
        {
            // We only handle clicks that are on the top card. e.X gives the horizontal distance
            // from the edge of the discard pile to the click location.
            if (uxDiscardPile.IsOnTopCard(e.X))
            {
                _game.SelectDiscard(uxDiscardPile);
                Refresh();
            }
        }

        /// <summary>
        /// Ends the game.
        /// </summary>
        private void EndGame()
        {
            Refresh();
            MessageBox.Show("You win!");
            uxBoard.Enabled = false;
        }

        /// <summary>
        /// Handles a MouseClick event on a tableau column.
        /// </summary>
        /// <param name="sender">The TableauColumn that was clicked.</param>
        /// <param name="e">Data regarding the mouse click.</param>
        private void uxTableauColumn_MouseClick(object sender, MouseEventArgs e)
        {
            TableauColumn col = (TableauColumn)sender;

            // We only handle clicks that are on a card or an empty column.
            // e.Y gives the vertical distance from the top of the control to the click location.
            int n = col.NumberAbove(e.Y);
            if (n > 0 || (n == 0 && col.FaceUpPile.Count == 0))
            {
                if (_game.SelectTableauCards(col, n))
                {
                    EndGame();
                }
                Refresh();
            }
        }

        /// <summary>
        /// Handles a MouseClick event on a foundation pile.
        /// </summary>
        /// <param name="sender">The CardPile that was clicked.</param>
        /// <param name="e"></param>
        private void uxFoundation_MouseClick(object sender, MouseEventArgs e)
        {
            if (_game.MoveSelectionToFoundation(((CardPile)sender).Pile))
            {
                EndGame();
            }
            Refresh();
        }
    }
}
