﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNASystem.Interfaces;
using XNASystem.Utils;

namespace XNASystem.MaterialEditor
{
	class SelectBookletMenu : IScreen
	{
		#region variables

		protected int _up;
		protected int _down;
		protected int _enter;
		protected int _choice;
		protected Stack<IScreen> _menuStack;
		protected SystemMain _systemMain;
		protected EditorMainMenu _editor;

		#endregion

		#region constructor
		public SelectBookletMenu(Stack<IScreen> stack, SystemMain main, EditorMainMenu editor)
		{
			_up = 1;
			_down = 1;
			_enter = 1;
			_choice = 0;
			_menuStack = stack;
			_systemMain = main;
			_editor = editor;
		}
		#endregion

		#region update
		public void Update(InputHandler handler)
		{
			_choice = handler.HandleMenuMovement(1, _choice);
			if(handler.IfEnterPressed())
			{
				_menuStack.Pop();
				_systemMain.SetStack(_menuStack);
			}
		}

		#endregion

		#region draw
		public void Draw(SpriteBatch spriteBatch, List<SpriteFont> fonts, List<Texture2D> textures)
		{
			spriteBatch.Begin();

			//draw the background
			spriteBatch.Draw(textures[1], new Rectangle(0, 0, 800, 600), Color.White);

			// draw the selection box
			//spriteBatch.Draw(textures[0], new Vector2(75, 175 + ((300 / (_systemMain.GetBookletList().Count + 1)) * _choice)), Color.White);

			//draw the title
			spriteBatch.DrawString(fonts[0], "Choose a booklet", new Vector2(250, 100), Color.Black);

			//draw the menu items
			int counter;
			/*for (counter = 0; counter < _systemMain.GetBookletList().Count; counter++)
			{
				spriteBatch.DrawString(fonts[0], _systemMain.GetBookletList()[counter].GetTitle(), new Vector2(100, 200 + ((300 / (_systemMain.GetBookletList().Count + 1)) * counter)), Color.Black);
			}*/
			//spriteBatch.DrawString(fonts[0], "Create New Booklet", new Vector2(100, 200 + ((300 / (_systemMain.GetBookletList().Count + 1)) * counter)), Color.Black);
			spriteBatch.DrawString(fonts[0], "Back", new Vector2(100, 500), Color.Black);

			spriteBatch.End();
		}
		#endregion
	}
}