using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JibbyIsMyFriend
{
    public class AssetsManager
    {
        public static Texture2D ButtonWashingUp;
        public static Texture2D ButtonWashingDown;
        public static Texture2D ButtonEatingUp;
        public static Texture2D ButtonEatingDown;

        public static Texture2D Background;

        public static Dictionary<JibbyEmotionalStates, Texture2D> Textures { get; set; }
        public static Dictionary<string, Texture2D> ActionTextures { get; set; }

        public static SpriteFont Verdana;
        

        public AssetsManager()
        {
            // Initialize
            Textures = new Dictionary<JibbyEmotionalStates, Texture2D>();
            ActionTextures = new Dictionary<string, Texture2D>();

            // Background
            Background                                = Game1.Instance.Content.Load<Texture2D>("jibby_bg");

            // States
            Textures.Add(JibbyEmotionalStates.Happy,    Game1.Instance.Content.Load<Texture2D>("JibbyHappy"));
            Textures.Add(JibbyEmotionalStates.Sad,      Game1.Instance.Content.Load<Texture2D>("JibbySad"));
            Textures.Add(JibbyEmotionalStates.Hungry,   Game1.Instance.Content.Load<Texture2D>("JibbyHungry"));
            Textures.Add(JibbyEmotionalStates.Dirty,    Game1.Instance.Content.Load<Texture2D>("JibbyDirty"));
            Textures.Add(JibbyEmotionalStates.Dead,     Game1.Instance.Content.Load<Texture2D>("JibbyDead"));

            // Actions                                  
            ActionTextures.Add("Eating",                Game1.Instance.Content.Load<Texture2D>("JibbyEating"));
            ActionTextures.Add("Washing",               Game1.Instance.Content.Load<Texture2D>("JibbyWashing"));

            // Buttons                                  
            ButtonWashingUp                           = Game1.Instance.Content.Load<Texture2D>("btn_wash_off");
            ButtonWashingDown                         = Game1.Instance.Content.Load<Texture2D>("btn_wash_on");
            ButtonEatingUp                            = Game1.Instance.Content.Load<Texture2D>("btn_eat_off");
            ButtonEatingDown                          = Game1.Instance.Content.Load<Texture2D>("btn_eat_on");
                                            
            // Fonts                                    
            Verdana                                   = Game1.Instance.Content.Load<SpriteFont>("Verdana"); //14
        }                                               
    }
}
