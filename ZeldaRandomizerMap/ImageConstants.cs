using System.Drawing;

namespace ZeldaRandomizerMap
{
    class ImageConstants
    {
        private static Bitmap MakeDecal(string fileName)
        {
            Bitmap original = new Bitmap(fileName);
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

        public static readonly Bitmap BaseImage = new Bitmap(@"zelda\map_dark.png");
        public static readonly Bitmap Level1Image = MakeDecal(@"zelda\level_1.png");
        public static readonly Bitmap Level2Image = MakeDecal(@"zelda\level_2.png");
        public static readonly Bitmap Level3Image = MakeDecal(@"zelda\level_3.png");
        public static readonly Bitmap Level4Image = MakeDecal(@"zelda\level_4.png");
        public static readonly Bitmap Level5Image = MakeDecal(@"zelda\level_5.png");
        public static readonly Bitmap Level6Image = MakeDecal(@"zelda\level_6.png");
        public static readonly Bitmap Level7Image = MakeDecal(@"zelda\level_7.png");
        public static readonly Bitmap Level8Image = MakeDecal(@"zelda\level_8.png");
        public static readonly Bitmap Level9Image = MakeDecal(@"zelda\level_9.png");
        public static readonly Bitmap BibleImage = MakeDecal(@"zelda\bible.png");
        public static readonly Bitmap CandleImage = MakeDecal(@"zelda\candle.png");
        public static readonly Bitmap ArrowImage = MakeDecal(@"zelda\arrow.png");
        public static readonly Bitmap FoodImage = MakeDecal(@"zelda\food.png");
        public static readonly Bitmap BlueRingImage = MakeDecal(@"zelda\blue_ring.png");
        public static readonly Bitmap KeyImage = MakeDecal(@"zelda\key.png");
        public static readonly Bitmap BombImage = MakeDecal(@"zelda\bomb.png");
        public static readonly Bitmap HintImage = MakeDecal(@"zelda\hint.png");
        public static readonly Bitmap MagicalSwordImage = MakeDecal(@"zelda\magical_sword.png");
        public static readonly Bitmap MoneyImage = MakeDecal(@"zelda\money.png");
        public static readonly Bitmap PotionImage = MakeDecal(@"zelda\potion.png");
        public static readonly Bitmap WarpZone1Image = MakeDecal(@"zelda\warp_zone_1.png");
        public static readonly Bitmap WarpZone2Image = MakeDecal(@"zelda\warp_zone_2.png");
        public static readonly Bitmap WarpZone3Image = MakeDecal(@"zelda\warp_zone_3.png");
        public static readonly Bitmap WarpZone4Image = MakeDecal(@"zelda\warp_zone_4.png");
        public static readonly Bitmap WhiteSwordImage = MakeDecal(@"zelda\white_sword.png");
        public static readonly Bitmap StairsRoomBitmapA = new Bitmap(@"zelda\stairs_a.png");
        public static readonly Bitmap StairsRoomBitmapB = new Bitmap(@"zelda\stairs_b.png");
        public static readonly Bitmap StairsRoomBitmapC = new Bitmap(@"zelda\stairs_c.png");
        public static readonly Bitmap StairsRoomBitmapD = new Bitmap(@"zelda\stairs_d.png");
        public static readonly Bitmap StairsRoomBitmapE = new Bitmap(@"zelda\stairs_e.png");
        public static readonly Bitmap StairsRoomBitmapF = new Bitmap(@"zelda\stairs_f.png");
        public static readonly Bitmap StairsRoomBitmapX = new Bitmap(@"zelda\stairs_x.png");
        public static readonly Bitmap PendingRoomBitmap = MakeSolidBitmap(Color.Black);
        public static readonly Bitmap ClearRoomBitmap = MakeSolidBitmap(Color.White);
        public static readonly Bitmap SolidRoomBitmap = MakeSolidBitmap(Color.Red);
        public static readonly Bitmap NearPatraRoomBitmap = MakeSolidBitmap(Color.Yellow);
        public static readonly Bitmap NearGanonRoomBitmap = MakeSolidBitmap(Color.Pink);
        public static readonly Bitmap GanonRoomBitmap = MakeSolidBitmap(Color.Magenta);
        public static readonly Bitmap ZeldaRoomBitmap = MakeSolidBitmap(Color.Cyan);
        public static readonly Bitmap PendingWallBitmap = MakeSolidBitmap(Color.Black);
        public static readonly Bitmap ClearWallBitmap = MakeSolidBitmap(Color.White);
        public static readonly Bitmap SolidWallBitmap = MakeSolidBitmap(Color.Red);
        public static readonly Bitmap KeyWallBitmap = MakeSolidBitmap(Color.Orange);
        public static readonly Bitmap ShutterWallBitmap = MakeSolidBitmap(Color.Lime);
    }
}
