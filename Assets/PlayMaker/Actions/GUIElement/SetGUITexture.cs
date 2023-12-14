// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;
using UnityEngine.UI;
using System;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.GUIElement)]
	[Tooltip("Sets the Texture used by the GUITexture attached to a Game Object.")]
	#if UNITY_2017_2_OR_NEWER
	#pragma warning disable CS0618  
	[Obsolete("GUITexture is part of the legacy UI system and will be removed in a future release")]
	#endif
	public class SetGUITexture : ComponentAction<Image>
	{
		[RequiredField]
		[CheckForComponent(typeof(Image))]
		[Tooltip("The GameObject that owns the GUITexture.")]
        public FsmOwnerDefault gameObject;

        [Tooltip("Texture to apply.")]
		public FsmTexture texture;
		
		public override void Reset()
		{
			gameObject = null;
			texture = null;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(go))
			{
				Texture2D tex = texture.Value as Texture2D;
				var rect = new Rect(0, 0, tex.width, tex.height);
				guiTexture.sprite = Sprite.Create(tex, rect, new Vector2(0.5f, 0.5f));
			}
			
			Finish();
		}
	}
}