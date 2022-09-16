/* Game.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ksu.Cis300.Klondike
{
    /// <summary>
    /// The game controller.
    /// </summary>
    public class Game
    {
        
        /// <summary>
        /// keep track of discard pile being selected
        /// </summary>
        private DiscardPile _currentDPile = new DiscardPile();
        
        /// <summary>
        /// keep track of tableau column being selected 
        /// </summary>
        private TableauColumn _currentTableauColumn = new TableauColumn();

        /// <summary>
        /// int to keep track of number of face down tableau cards 
        /// </summary>
        private int faceDown = 21;

        /// <summary>
        /// int to keep track of cards in the stock and discard pile 
        /// </summary>
        private int stockCards = 24;

        /// <summary>
        /// stack created for the transferCards method
        /// </summary>
        private Stack<Card> tempStack = new Stack<Card>();

        /// <summary>
        /// Method to transfer cards to different stacks 
        /// </summary>
        /// <param name="firstStack">loaction/cards being moved </param>
        /// <param name="secondStack">new location for the cards9</param>
        /// <param name="numCards">int for how many cards being moved </param>
        private void TransferCards(Stack<Card> firstStack , Stack<Card> secondStack , int numCards )
        {
           for ( int i = 0; i < numCards; i++)
            {
                tempStack.Push(firstStack.Pop());
                secondStack.Push(tempStack.Pop());
            }        
                    
        }
        /// <summary>
        /// 
        /// </summary>
        private void RemoveSelection()
        {
            if (_currentDPile != null)
            {
                _currentDPile.IsSelected = false;
                _currentDPile = null;
            }
            if (_currentTableauColumn != null)
            {
                _currentTableauColumn.NumberSelected = 0;
                _currentTableauColumn = null;
                
            }

        }


        /// <summary>
        /// bool to tell if tableau move is legal
        /// </summary>
        /// <param name="cardMoved">card attempting to be moved </param>
        /// <param name="newStack">location to move said card </param>
        /// <returns>bool if move is legal</returns>
        private bool LegalTableau(Card cardMoved, Stack<Card> newStack )
        {
            if(cardMoved.Rank == 13 && newStack.Count == 0) // King to empty space 
            {
                return true;
            }
            
            if ((cardMoved.Rank == newStack.Peek().Rank - 1) && (cardMoved.IsRed != newStack.Peek().IsRed))
            {
                return true;
            }
            
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Checking to see if a move to the foundation is legal 
        /// </summary>
        /// <param name="cardMoved">the card you are going to move </param>
        /// <param name="newStack">location to be moved </param>
        /// <returns>a bool telling if move is legal</returns>
        private bool LegalFoundation(Card cardMoved, Stack<Card> newStack)
        {
            
            if (cardMoved.Rank == 1 && newStack.Count == 0) // if it is an ace 
            {
                return true;
            }
            else if (cardMoved.Rank!= 1 && newStack.Count == 0)
            {
                return false;
            }
                
            if((cardMoved.Rank -1 == newStack.Peek().Rank) && (cardMoved.Suit == newStack.Peek().Suit)) // if it is one more and same suit 
            {
                return true;
            }
            
            
            else
            {
                return false; // not a legal move 
            }
        }
        /// <summary>
        /// checks if you won the game 
        /// </summary>
        /// <returns>bool if you won the game</returns>
        private bool GameWon()
        {
            if (faceDown == 0 && stockCards == 1)
            {
                MessageBox.Show("You Won!!!"); //YAY YOU WON
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnCheck"></param>
        private void FlipColumnCard(TableauColumn columnCheck)
        {
           if(columnCheck.FaceUpPile.Count == 0 &&(columnCheck.FaceDownPile.Count > 0))
            {
                columnCheck.FaceUpPile.Push(columnCheck.FaceDownPile.Pop()); // moves face down card to face up

                --faceDown; //updates private int

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardDeck"></param>
        /// <param name="gameColumns"></param>
        private void DealCards(Stack<Card> cardDeck, TableauColumn[] gameColumns)
        {
            for (int i = 0; i < gameColumns.Length; ++i)
            {
                TransferCards(cardDeck, gameColumns[i].FaceUpPile, 1);
                for (int j = 1; j <= (6 - i); ++j)
            
                
            
                TransferCards(cardDeck, gameColumns[i + j].FaceDownPile, 1);
            }
            _currentDPile = null;
            _currentTableauColumn = null;
        }
        /// <summary>
        /// Moves from the discard to the tableau
        /// </summary>
        /// <param name="cardMoved">where the card will be moved</param>
        private void MoveDiscard(Stack<Card> cardMoved)
        {
            if(LegalTableau(_currentDPile.Pile.Peek(),cardMoved) == true) 
            {
                TransferCards(_currentDPile.Pile, cardMoved, 1);
            }
            RemoveSelection();
        }
        private void MoveDiscardToFoundation(Stack<Card> foundationPile)
        {
            if (LegalFoundation(_currentDPile.Pile.Peek(), foundationPile) == true)
            {
                TransferCards(_currentDPile.Pile, foundationPile, 1);
            }
            RemoveSelection();
        }
        /// <summary>
        /// Method to move card(s) from a tableau to a tableau
        /// </summary>
        /// <param name="otherTableau">The tableau you are attempting to move to </param>
        private void MoveTableauToTableau(Stack<Card> otherTableau)
        {
            Stack<Card> tempStack = new Stack<Card>();
            TransferCards(_currentTableauColumn.FaceUpPile, tempStack, _currentTableauColumn.FaceUpPile.Count);
            if (LegalTableau(tempStack.Peek(), otherTableau))
            {
                TransferCards(tempStack, otherTableau, tempStack.Count);
                if (_currentTableauColumn.FaceUpPile.Count == 0)
                {
                    FlipColumnCard(_currentTableauColumn);

                }

            }
           
            else
            {
                for(int i =0; i< tempStack.Count; ++i)
                {
                    _currentTableauColumn.FaceUpPile.Push(tempStack.Pop());
                }
            }
            
            RemoveSelection();

        }
        /// <summary>
        /// Method to move cards from the tableau to the foundation 
        /// </summary>
        /// <param name="foundationPile">the foundation pile you are attempting to move to</param>
        private void MoveTableauToFoundation(Stack<Card> foundationPile)
        {
            if(LegalFoundation(_currentTableauColumn.FaceUpPile.Peek(), foundationPile))
            {
                    TransferCards(_currentTableauColumn.FaceUpPile, foundationPile, 1);
                if (_currentTableauColumn.FaceUpPile.Count == 0)
                {
                    FlipColumnCard(_currentTableauColumn);

                }
            }
            RemoveSelection();
           
        }
        
       
      
        
        /// <summary>
        /// The random number generator.
        /// </summary>
        private Random _randomNumbers;

        /// <summary>
        /// Gets a new card deck.
        /// </summary>
        /// <returns>The new card deck.</returns>
        private Card[] GetNewDeck()
        {
            Card[] cards = new Card[52];
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = new Card(i % 13 + 1, (Suit)(i / 13));
            }
            return cards;
        }

        /// <summary>
        /// Shuffles a new deck and pushes the cards onto the given stack.
        /// </summary>
        /// <param name="shuffled">The stack on which to push the cards.</param>
        private void ShuffleNewDeck(Stack<Card> shuffled)
        {
            Card[] deck = GetNewDeck();
            for (int i = deck.Length - 1; i >= 0; i--)
            {
                // Get a random nonnegative integer less than or equal to i.
                int j = _randomNumbers.Next(i + 1);

                shuffled.Push(deck[j]);
                deck[j] = deck[i];
            }
        }

        /// <summary>
        /// Constructs a new game from the given controls and seed.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <param name="tableau">The tableau columns.</param>
        /// <param name="seed">The random number seed. If -1, no seed is used.</param>
        public Game(CardPile stock, TableauColumn[] tableau, int seed)
        {
            if (seed == -1)
            {
                _randomNumbers = new Random();
            }
            else
            {
                _randomNumbers = new Random(seed);
            }
            ShuffleNewDeck(stock.Pile);
            DealCards(stock.Pile, tableau);
        }

        /// <summary>
        /// Draws the next three cards from the stock, or returns the discard pile to the stock
        /// if the stock is empty.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <param name="discard">The discard pile.</param>
        public void DrawCardsFromStock(CardPile stock, DiscardPile discard)
        {
            if (stock.Pile.Count == 0) // if the stock is empty 
            {
                TransferCards(discard.Pile, stock.Pile, discard.Pile.Count);
            }
            else if (stock.Pile.Count >= 3)
            {
                TransferCards(stock.Pile, discard.Pile, 3);
            }
            else
            {
                TransferCards(stock.Pile, discard.Pile, stock.Pile.Count);
            }
        }

        /// <summary>
        /// Selects the top discarded card, or removes the selection if there already is one.
        /// </summary>
        /// <param name="discard">The discard pile.</param>
        public void SelectDiscard(DiscardPile discard)
        {
            if (_currentDPile != null)
            {
                RemoveSelection();

            }
            if (_currentTableauColumn != null)
            {
                RemoveSelection();
            }
            else
            {
                _currentDPile = discard;
                _currentDPile.IsSelected = true;
            }
        }

        /// <summary>
        /// Selects the given number of cards from the given tableau column or tries to move
        /// any currently-selected cards to the given tableau column.
        /// </summary>
        /// <param name="col">The column to select or to move cards to.</param>
        /// <param name="n">The number of cards to select.</param>
        /// <returns>Whether the play wins the game.</returns>
        public bool SelectTableauCards(TableauColumn col, int n)
        {
            if (_currentTableauColumn == col)
            {
                RemoveSelection();
            }
            else if (_currentDPile != null && n <= 1)
            {
                MoveDiscard(col.FaceUpPile);
            }
            else if (_currentTableauColumn != null && n <= 1)
            {
                MoveTableauToTableau(col.FaceUpPile);
            }
            else 
            {
                _currentTableauColumn = col;
                _currentTableauColumn.NumberSelected = n;

            }
            return GameWon();
            
        }



        /// <summary>
        /// Moves the selected card to the given foundation pile, if possible
        /// </summary>
        /// <param name="dest">The foundation pile.</param>
        /// <returns>Whether the move wins the game.</returns>
        public bool MoveSelectionToFoundation(Stack<Card> dest)
        {
            if(_currentTableauColumn != null)
            {
                MoveTableauToFoundation(dest);
            }
             else if(_currentDPile != null)
            {
                MoveDiscardToFoundation(dest);
            }
            RemoveSelection();
            return GameWon();
        }
    }
}
