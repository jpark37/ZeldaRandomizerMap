using System.Drawing;
using ZeldaRandomizerMap.Properties;

namespace ZeldaRandomizerMap
{
    class ImageConstants
    {
        private static Bitmap MakeDecal(Bitmap original)
        {
            Bitmap decal = new Bitmap(128, 128);
            for (int y = 0; y < decal.Height; ++y)
            {
                for (int x = 0; x < decal.Width; ++x)
                {
                    decal.SetPixel(x, y, original.GetPixel((x * original.Width) / decal.Width, (y * original.Width) / decal.Height));
                }
            }
            return decal;
        }

        private static Bitmap MakeSolidBitmap(Color color)
        {
            Bitmap bitmap = new Bitmap(64, 64);

            for (int y = 0; y < bitmap.Height; ++y)
            {
                for (int x = 0; x < bitmap.Width; ++x)
                {
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }

        public static readonly Bitmap BaseImage = Resources.MapDark;
        public static readonly Bitmap Level1Image = MakeDecal(Resources.Level1);
        public static readonly Bitmap Level2Image = MakeDecal(Resources.Level2);
        public static readonly Bitmap Level3Image = MakeDecal(Resources.Level3);
        public static readonly Bitmap Level4Image = MakeDecal(Resources.Level4);
        public static readonly Bitmap Level5Image = MakeDecal(Resources.Level5);
        public static readonly Bitmap Level6Image = MakeDecal(Resources.Level6);
        public static readonly Bitmap Level7Image = MakeDecal(Resources.Level7);
        public static readonly Bitmap Level8Image = MakeDecal(Resources.Level8);
        public static readonly Bitmap Level9Image = MakeDecal(Resources.Level9);
        public static readonly Bitmap BibleImage = MakeDecal(Resources.Bible);
        public static readonly Bitmap CandleImage = MakeDecal(Resources.Candle);
        public static readonly Bitmap ArrowImage = MakeDecal(Resources.Arrow);
        public static readonly Bitmap FoodCheapImage = MakeDecal(Resources.Food);
        public static readonly Bitmap FoodExpensiveImage = MakeDecal(Resources.FoodExpensive);
        public static readonly Bitmap BlueRingImage = MakeDecal(Resources.BlueRing);
        public static readonly Bitmap KeyCheapImage = MakeDecal(Resources.Key);
        public static readonly Bitmap KeyExpensiveImage = MakeDecal(Resources.KeyExpensive);
        public static readonly Bitmap BombImage = MakeDecal(Resources.Bomb);
        public static readonly Bitmap HintImage = MakeDecal(Resources.Hint);
        public static readonly Bitmap MagicalSwordImage = MakeDecal(Resources.MagicalSword);
        public static readonly Bitmap MoneyImage = MakeDecal(Resources.Money);
        public static readonly Bitmap HeartImage = MakeDecal(Resources.Heart);
        public static readonly Bitmap PotionImage = MakeDecal(Resources.Potion);
        public static readonly Bitmap SwordImage = MakeDecal(Resources.Sword);
        public static readonly Bitmap WarpZone1Image = MakeDecal(Resources.WarpZone1);
        public static readonly Bitmap WarpZone2Image = MakeDecal(Resources.WarpZone2);
        public static readonly Bitmap WarpZone3Image = MakeDecal(Resources.WarpZone3);
        public static readonly Bitmap WarpZone4Image = MakeDecal(Resources.WarpZone4);
        public static readonly Bitmap WhiteSwordImage = MakeDecal(Resources.WhiteSword);
        public static readonly Bitmap StairsRoomBitmapA = Resources.StairsA;
        public static readonly Bitmap StairsRoomBitmapB = Resources.StairsB;
        public static readonly Bitmap StairsRoomBitmapC = Resources.StairsC;
        public static readonly Bitmap StairsRoomBitmapD = Resources.StairsD;
        public static readonly Bitmap StairsRoomBitmapE = Resources.StairsE;
        public static readonly Bitmap StairsRoomBitmapF = Resources.StairsF;
        public static readonly Bitmap StairsRoomBitmapX = Resources.StairsX;
        public static readonly Bitmap PendingRoomBitmap = MakeSolidBitmap(Color.Black);
        public static readonly Bitmap ClearRoomBitmap = MakeSolidBitmap(Color.White);
        public static readonly Bitmap SolidRoomBitmap = MakeSolidBitmap(Color.Red);
        public static readonly Bitmap BlueBubbleRoomBitmap = MakeSolidBitmap(Color.Blue);
        public static readonly Bitmap NearPatraRoomBitmap = MakeSolidBitmap(Color.Yellow);
        public static readonly Bitmap NearGannonRoomBitmap = MakeSolidBitmap(Color.Pink);
        public static readonly Bitmap GannonRoomBitmap = MakeSolidBitmap(Color.Magenta);
        public static readonly Bitmap ZeldaRoomBitmap = MakeSolidBitmap(Color.Cyan);
        public static readonly Bitmap PendingWallBitmap = MakeSolidBitmap(Color.Black);
        public static readonly Bitmap ClearWallBitmap = MakeSolidBitmap(Color.White);
        public static readonly Bitmap SolidWallBitmap = MakeSolidBitmap(Color.Red);
        public static readonly Bitmap KeyWallBitmap = MakeSolidBitmap(Color.Orange);
        public static readonly Bitmap ShutterWallBitmap = MakeSolidBitmap(Color.Lime);
    }
}
