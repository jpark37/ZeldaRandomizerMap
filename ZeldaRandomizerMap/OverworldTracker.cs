using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ZeldaRandomizerMap
{
    class OverworldTracker
    {
        enum CellType
        {
            None,
            Free,
            Armos,
            Bomb,
            Candle,
            Bracelet,
            Raft,
            Ladder,
            Recorder,
            BombLadder,
        }

        enum ExploreType
        {
            None,
            L1,
            L2,
            L3,
            L4,
            L5,
            L6,
            L7,
            L8,
            L9,
            LevelUnknown,
            Shop,
            Potion,
            WhiteSword,
            MagicalSword,
            WarpZone1,
            WarpZone2,
            WarpZone3,
            WarpZone4,
            Hint,
            Money,
        }

        [Flags]
        enum ShopType
        {
            None = 0,
            BlueCandle = 1,
            Arrow = 2,
            Food = 4,
            BlueRing = 8,
            Key = 16,
            Bomb = 32,
            All = ShopType.BlueCandle | ShopType.Arrow | ShopType.Food | ShopType.BlueRing | ShopType.Key | ShopType.Bomb,
        }

        enum OverworldType
        {
            First,
            Second,
            Mixed,
        }

        public OverworldTracker(PictureBox unexploredPictureBox, PictureBox exploredPictureBox)
        {
            m_unexploredPictureBox = unexploredPictureBox;
            m_exploredPictureBox = exploredPictureBox;

            UpdateUnexploredImage();
            UpdateExploredImage();
        }

        public void ClearCell()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.None;
            m_shopCells[m_activeRow, m_activeColumn] = ShopType.None;
            UpdateExploredImage();
        }

        public void SetActiveCell(int row, int column)
        {
            m_activeRow = row;
            m_activeColumn = column;
        }

        public void ExploreCell(int row, int column)
        {
            SetActiveCell(row, column);
            m_cells[row, column] = CellType.None;
            UpdateUnexploredImage();
        }

        public void SetNoteL1()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.L1;
            UpdateExploredImage();
        }

        public void SetNoteL2()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.L2;
            UpdateExploredImage();
        }

        public void SetNoteL3()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.L3;
            UpdateExploredImage();
        }

        public void SetNoteL4()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.L4;
            UpdateExploredImage();
        }

        public void SetNoteL5()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.L5;
            UpdateExploredImage();
        }

        public void SetNoteL6()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.L6;
            UpdateExploredImage();
        }

        public void SetNoteL7()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.L7;
            UpdateExploredImage();
        }

        public void SetNoteL8()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.L8;
            UpdateExploredImage();
        }

        public void SetNoteL9()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.L9;
            UpdateExploredImage();
        }

        public void SetNoteLevelUnknown()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.LevelUnknown;
            UpdateExploredImage();
        }

        public void SetNoteShopCandle()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.Shop;
            m_shopCells[m_activeRow, m_activeColumn] |= ShopType.BlueCandle;
            UpdateExploredImage();
        }

        public void SetNoteShopArrow()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.Shop;
            m_shopCells[m_activeRow, m_activeColumn] |= ShopType.Arrow;
            UpdateExploredImage();
        }

        public void SetNoteShopFood()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.Shop;
            m_shopCells[m_activeRow, m_activeColumn] |= ShopType.Food;
            UpdateExploredImage();
        }

        public void SetNoteShopRing()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.Shop;
            m_shopCells[m_activeRow, m_activeColumn] |= ShopType.BlueRing;
            UpdateExploredImage();
        }

        public void SetNoteShopKey()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.Shop;
            m_shopCells[m_activeRow, m_activeColumn] |= ShopType.Key;
            UpdateExploredImage();
        }

        public void SetNoteShopBomb()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.Shop;
            m_shopCells[m_activeRow, m_activeColumn] |= ShopType.Bomb;
            UpdateExploredImage();
        }

        public void SetNotePotion()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.Potion;
            UpdateExploredImage();
        }

        public void SetNoteWhiteSword()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.WhiteSword;
            UpdateExploredImage();
        }

        public void SetNoteMagicalSword()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.MagicalSword;
            UpdateExploredImage();
        }

        public void SetNoteWarpZone1()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.WarpZone1;
            UpdateExploredImage();
        }

        public void SetNoteWarpZone2()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.WarpZone2;
            UpdateExploredImage();
        }

        public void SetNoteWarpZone3()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.WarpZone3;
            UpdateExploredImage();
        }

        public void SetNoteWarpZone4()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.WarpZone4;
            UpdateExploredImage();
        }

        public void SetNoteHint()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.Hint;
            UpdateExploredImage();
        }

        public void SetNoteMoney()
        {
            m_exploredCells[m_activeRow, m_activeColumn] = ExploreType.Money;
            UpdateExploredImage();
        }

        public void SetShopFilterAll()
        {
            m_shopFilter = ShopType.All;
            UpdateExploredImage();
        }

        public void SetShopFilterCandle()
        {
            m_shopFilter = ShopType.BlueCandle;
            UpdateExploredImage();
        }

        public void SetShopFilterArrow()
        {
            m_shopFilter = ShopType.Arrow;
            UpdateExploredImage();
        }

        public void SetShopFilterFood()
        {
            m_shopFilter = ShopType.Food;
            UpdateExploredImage();
        }

        public void SetShopFilterRing()
        {
            m_shopFilter = ShopType.BlueRing;
            UpdateExploredImage();
        }

        public void SetShopFilterKey()
        {
            m_shopFilter = ShopType.Key;
            UpdateExploredImage();
        }

        public void SetShopFilterBomb()
        {
            m_shopFilter = ShopType.Bomb;
            UpdateExploredImage();
        }

        public void SetHasCandle(bool owned)
        {
            m_hasCandle = owned;
            UpdateExploredImage();
        }

        public void SetHasArrow(bool owned)
        {
            m_hasArrow = owned;
            UpdateExploredImage();
        }

        public void SetHasFood(bool owned)
        {
            m_hasFood = owned;
            UpdateExploredImage();
        }

        public void SetHasRing(bool owned)
        {
            m_hasRing = owned;
            UpdateExploredImage();
        }

        public void SetHasKey(bool owned)
        {
            m_hasKey = owned;
            UpdateExploredImage();
        }

        public void SetFirstQuest()
        {
            m_cells = (CellType[,])StartingCells1.Clone();
            m_overworldType = OverworldType.First;
            UpdateUnexploredImage();
        }

        public void SetSecondQuest()
        {
            m_cells = (CellType[,])StartingCells2.Clone();
            m_overworldType = OverworldType.Second;
            UpdateUnexploredImage();
        }

        public void SetMixedQuest()
        {
            m_cells = (CellType[,])StartingCellsMixed.Clone();
            m_overworldType = OverworldType.Mixed;
            UpdateUnexploredImage();
        }

        public void ResetCell()
        {
            switch (m_overworldType)
            {
                case OverworldType.First:
                    m_cells[m_activeRow, m_activeColumn] = StartingCells1[m_activeRow, m_activeColumn];
                    break;
                case OverworldType.Second:
                    m_cells[m_activeRow, m_activeColumn] = StartingCells2[m_activeRow, m_activeColumn];
                    break;
                case OverworldType.Mixed:
                    m_cells[m_activeRow, m_activeColumn] = StartingCellsMixed[m_activeRow, m_activeColumn];
                    break;
            }
            UpdateUnexploredImage();
        }

        private bool FilteredShopItem(int row, int column, ShopType shopType)
        {
            ShopType filteredShopType = m_shopFilter;
            if (m_hasCandle)
            {
                filteredShopType &= ~ShopType.BlueCandle;
            }
            if (m_hasArrow)
            {
                filteredShopType &= ~ShopType.Arrow;
            }
            if (m_hasFood)
            {
                filteredShopType &= ~ShopType.Food;
            }
            if (m_hasRing)
            {
                filteredShopType &= ~ShopType.BlueRing;
            }
            if (m_hasKey)
            {
                filteredShopType &= ~ShopType.Key;
            }
            return filteredShopType.HasFlag(shopType) && m_shopCells[row, column].HasFlag(shopType);
        }

        private void UpdateUnexploredImage()
        {
            Bitmap bitmap = new Bitmap(ImageConstants.BaseImage);
            int width = bitmap.Width;
            int height = bitmap.Height;
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            int stride = bitmapdata.Stride;
            unsafe
            {
                byte* scan0 = (byte*)bitmapdata.Scan0.ToPointer();
                for (int y = 0; y < 8; ++y)
                {
                    for (int x = 0; x < 16; ++x)
                    {
                        int offsetX = (x * width) / 16;
                        int offsetY = (y * height) / 8;
                        CellType cellType = m_cells[y, x];
                        for (int decalY = 0; decalY < 128; ++decalY)
                        {
                            for (int decalX = 0; decalX < 128; ++decalX)
                            {
                                if (m_cells[y, x] != CellType.None)
                                {
                                    int scanX = (offsetX + decalX) * 4;
                                    int scanY = (offsetY + decalY) * stride;
                                    switch (m_cells[y, x])
                                    {
                                        case CellType.Free:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, decalX < 24 || decalY < 24 ? Color.White : Color.Red);
                                            break;
                                        case CellType.Armos:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, decalX < 24 || decalY < 24 ? Color.White : Color.Orange);
                                            break;
                                        case CellType.Bomb:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, decalX < 24 || decalY < 24 ? Color.White : Color.Yellow);
                                            break;
                                        case CellType.Candle:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, decalX < 24 || decalY < 24 ? Color.White : Color.Green);
                                            break;
                                        case CellType.Bracelet:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, decalX < 24 || decalY < 24 ? Color.White : Color.Blue);
                                            break;
                                        case CellType.Raft:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, decalX < 24 || decalY < 24 ? Color.White : Color.Violet);
                                            break;
                                        case CellType.Ladder:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, decalX < 24 || decalY < 24 ? Color.White : Color.Cyan);
                                            break;
                                        case CellType.Recorder:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, decalX < 24 || decalY < 24 ? Color.White : Color.Magenta);
                                            break;
                                        case CellType.BombLadder:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, decalX < 24 || decalY < 24 ? Color.White : Color.White);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            bitmap.UnlockBits(bitmapdata);
            m_unexploredPictureBox.Image = bitmap;
        }

        unsafe private void UpdateImageCell(byte* scan0, int scanX, int scanY, Color color)
        {
            scan0[scanX + scanY] = color.B;
            scan0[scanX + scanY + 1] = color.G;
            scan0[scanX + scanY + 2] = color.R;
        }

        private void UpdateExploredImage()
        {
            Bitmap bitmap = new Bitmap(ImageConstants.BaseImage);
            int width = bitmap.Width;
            int height = bitmap.Height;
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            int stride = bitmapdata.Stride;
            unsafe
            {
                byte* scan0 = (byte*)bitmapdata.Scan0.ToPointer();
                for (int row = 0; row < 8; ++row)
                {
                    for (int column = 0; column < 16; ++column)
                    {
                        int offsetX = (column * width) / 16;
                        int offsetY = (row * height) / 8;
                        CellType cellType = m_cells[row, column];
                        for (int decalY = 0; decalY < 128; ++decalY)
                        {
                            for (int decalX = 0; decalX < 128; ++decalX)
                            {
                                ExploreType exploreType = m_exploredCells[row, column];
                                if (exploreType != ExploreType.None)
                                {
                                    int scanX = (offsetX + decalX) * 4;
                                    int scanY = (offsetY + decalY) * stride;
                                    switch (exploreType)
                                    {
                                        case ExploreType.L1:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.Level1Image.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.L2:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.Level2Image.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.L3:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.Level3Image.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.L4:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.Level4Image.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.L5:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.Level5Image.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.L6:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.Level6Image.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.L7:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.Level7Image.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.L8:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.Level8Image.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.L9:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.Level9Image.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.LevelUnknown:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, Color.White);
                                            break;
                                        case ExploreType.Shop:
                                            if (FilteredShopItem(row, column, ShopType.BlueCandle))
                                            {
                                                UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.CandleImage.GetPixel(decalX, decalY));
                                            }
                                            else if (FilteredShopItem(row, column, ShopType.Arrow))
                                            {
                                                UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.ArrowImage.GetPixel(decalX, decalY));
                                            }
                                            else if (FilteredShopItem(row, column, ShopType.Food))
                                            {
                                                UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.FoodImage.GetPixel(decalX, decalY));
                                            }
                                            else if (FilteredShopItem(row, column, ShopType.BlueRing))
                                            {
                                                UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.BlueRingImage.GetPixel(decalX, decalY));
                                            }
                                            else if (FilteredShopItem(row, column, ShopType.Key))
                                            {
                                                UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.KeyImage.GetPixel(decalX, decalY));
                                            }
                                            else if (FilteredShopItem(row, column, ShopType.Bomb))
                                            {
                                                UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.BombImage.GetPixel(decalX, decalY));
                                            }
                                            break;
                                        case ExploreType.Potion:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.PotionImage.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.WhiteSword:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.WhiteSwordImage.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.MagicalSword:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.MagicalSwordImage.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.WarpZone1:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.WarpZone1Image.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.WarpZone2:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.WarpZone2Image.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.WarpZone3:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.WarpZone3Image.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.WarpZone4:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.WarpZone4Image.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.Hint:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.HintImage.GetPixel(decalX, decalY));
                                            break;
                                        case ExploreType.Money:
                                            UpdateImageCell(scan0, (offsetX + decalX) * 4, (offsetY + decalY) * stride, ImageConstants.MoneyImage.GetPixel(decalX, decalY));
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            bitmap.UnlockBits(bitmapdata);
            m_exploredPictureBox.Image = bitmap;
        }

        static CellType[,] StartingCells1 =
        {
            { CellType.None, CellType.Bomb,   CellType.None,     CellType.Bomb,     CellType.Free,  CellType.Bomb, CellType.None,   CellType.Bomb,   CellType.None,   CellType.None,     CellType.Free,   CellType.Free,   CellType.Free,  CellType.Bomb,     CellType.Free,  CellType.Free },
            { CellType.Bomb, CellType.None,   CellType.Bomb,     CellType.Bomb,     CellType.Bomb,  CellType.None, CellType.Bomb,   CellType.None,   CellType.None,   CellType.None,     CellType.Free,   CellType.None,   CellType.Armos, CellType.Bracelet, CellType.Bomb,  CellType.Free },
            { CellType.None, CellType.Free,   CellType.Free,     CellType.Bracelet, CellType.Armos, CellType.Free, CellType.Bomb,   CellType.Bomb,   CellType.Candle, CellType.None,     CellType.None,   CellType.None,   CellType.Bomb,  CellType.Bomb,     CellType.None,  CellType.Raft },
            { CellType.None, CellType.None,   CellType.None,     CellType.Bomb,     CellType.Armos, CellType.None, CellType.None,   CellType.Free,   CellType.None,   CellType.None,     CellType.None,   CellType.None,   CellType.Free,  CellType.Armos,    CellType.None,  CellType.None },
            { CellType.None, CellType.None,   CellType.Recorder, CellType.None,     CellType.Free,  CellType.Raft, CellType.Candle, CellType.Candle, CellType.Candle, CellType.Bracelet, CellType.Free,   CellType.Candle, CellType.None,  CellType.Candle,   CellType.Armos, CellType.None },
            { CellType.None, CellType.Candle, CellType.None,     CellType.None,     CellType.None,  CellType.None, CellType.Candle, CellType.None,   CellType.None,   CellType.None,     CellType.None,   CellType.Candle, CellType.None,  CellType.None,     CellType.Free,  CellType.Ladder },
            { CellType.None, CellType.None,   CellType.Candle,   CellType.Candle,   CellType.Free,  CellType.None, CellType.Free,   CellType.Bomb,   CellType.Candle, CellType.None,     CellType.Candle, CellType.Candle, CellType.None,  CellType.Candle,   CellType.None,  CellType.Free },
            { CellType.Free, CellType.Bomb,   CellType.None,     CellType.None,     CellType.Free,  CellType.Free, CellType.Bomb,   CellType.Free,   CellType.Candle, CellType.Bracelet, CellType.None,   CellType.Bomb,   CellType.Bomb,  CellType.Bomb,     CellType.None,  CellType.None },
        };

        static CellType[,] StartingCells2 =
        {
            { CellType.Bomb,     CellType.Bomb,     CellType.Bomb,     CellType.Bomb,     CellType.Free,  CellType.None, CellType.Recorder, CellType.Bomb, CellType.None,       CellType.Bracelet,   CellType.Free,     CellType.None,     CellType.Free,     CellType.Bomb,     CellType.Free,     CellType.Free },
            { CellType.Bomb,     CellType.Bracelet, CellType.Bomb,     CellType.Bomb,     CellType.Bomb,  CellType.Bomb, CellType.Bomb,     CellType.None, CellType.BombLadder, CellType.BombLadder, CellType.Free,     CellType.Bracelet, CellType.Armos,    CellType.Bracelet, CellType.Bomb,     CellType.Free },
            { CellType.Free,     CellType.None,     CellType.Free,     CellType.Bracelet, CellType.Armos, CellType.Free, CellType.Bomb,     CellType.None, CellType.Candle,     CellType.Recorder,   CellType.None,     CellType.Recorder, CellType.None,     CellType.Bomb,     CellType.None,     CellType.Raft },
            { CellType.Recorder, CellType.None,     CellType.None,     CellType.Bomb,     CellType.Armos, CellType.None, CellType.None,     CellType.Free, CellType.None,       CellType.None,       CellType.Recorder, CellType.None,     CellType.Recorder, CellType.Armos,    CellType.None,     CellType.None },
            { CellType.None,     CellType.None,     CellType.None,     CellType.None,     CellType.Free,  CellType.Raft, CellType.Candle,   CellType.None, CellType.Candle,     CellType.Bracelet,   CellType.Free,     CellType.Candle,   CellType.None,     CellType.Candle,   CellType.Armos,    CellType.None },
            { CellType.None,     CellType.Candle,   CellType.None,     CellType.Candle,   CellType.None,  CellType.None, CellType.Candle,   CellType.None, CellType.Recorder,   CellType.None,       CellType.None,     CellType.Candle,   CellType.None,     CellType.None,     CellType.Free,     CellType.Ladder },
            { CellType.Recorder, CellType.None,     CellType.None,     CellType.Candle,   CellType.Free,  CellType.None, CellType.Free,     CellType.None, CellType.Candle,     CellType.None,       CellType.Candle,   CellType.None,     CellType.Candle,   CellType.None,     CellType.Recorder, CellType.Free },
            { CellType.Free,     CellType.None,     CellType.Recorder, CellType.None,     CellType.Free,  CellType.Free, CellType.Bomb,     CellType.Free, CellType.Candle,     CellType.Bracelet,   CellType.None,     CellType.None,     CellType.Bomb,     CellType.Bomb,     CellType.None,     CellType.None },
        };

        static CellType[,] StartingCellsMixed =
        {
            { CellType.Bomb,     CellType.Bomb,     CellType.Bomb,     CellType.Bomb,     CellType.Free,  CellType.Bomb, CellType.Recorder, CellType.Bomb,   CellType.None,       CellType.Bracelet,   CellType.Free,     CellType.Free,     CellType.Free,     CellType.Bomb,     CellType.Free,     CellType.Free },
            { CellType.Bomb,     CellType.Bracelet, CellType.Bomb,     CellType.Bomb,     CellType.Bomb,  CellType.Bomb, CellType.Bomb,     CellType.None,   CellType.BombLadder, CellType.BombLadder, CellType.Free,     CellType.Bracelet, CellType.Armos,    CellType.Bracelet, CellType.Bomb,     CellType.Free },
            { CellType.Free,     CellType.Free,     CellType.Free,     CellType.Bracelet, CellType.Armos, CellType.Free, CellType.Bomb,     CellType.Bomb,   CellType.Candle,     CellType.Recorder,   CellType.None,     CellType.Recorder, CellType.Bomb,     CellType.Bomb,     CellType.None,     CellType.Raft },
            { CellType.Recorder, CellType.None,     CellType.None,     CellType.Bomb,     CellType.Armos, CellType.None, CellType.None,     CellType.Free,   CellType.None,       CellType.None,       CellType.Recorder, CellType.None,     CellType.Recorder, CellType.Armos,    CellType.None,     CellType.None },
            { CellType.None,     CellType.None,     CellType.Recorder, CellType.None,     CellType.Free,  CellType.Raft, CellType.Candle,   CellType.Candle, CellType.Candle,     CellType.Bracelet,   CellType.Free,     CellType.Candle,   CellType.None,     CellType.Candle,   CellType.Armos,    CellType.None },
            { CellType.None,     CellType.Candle,   CellType.None,     CellType.Candle,   CellType.None,  CellType.None, CellType.Candle,   CellType.None,   CellType.Recorder,   CellType.None,       CellType.None,     CellType.Candle,   CellType.None,     CellType.None,     CellType.Free,     CellType.Ladder },
            { CellType.Recorder, CellType.None,     CellType.Candle,   CellType.Candle,   CellType.Free,  CellType.None, CellType.Free,     CellType.Bomb,   CellType.Candle,     CellType.None,       CellType.Candle,   CellType.Candle,   CellType.Candle,   CellType.Candle,     CellType.Recorder, CellType.Free },
            { CellType.Free,     CellType.Bomb,     CellType.Recorder, CellType.None,     CellType.Free,  CellType.Free, CellType.Bomb,     CellType.Free,   CellType.Candle,     CellType.Bracelet,   CellType.None,     CellType.Bomb,     CellType.Bomb,     CellType.Bomb,     CellType.None,     CellType.None },
        };

        CellType[,] m_cells = (CellType[,])StartingCells1.Clone();
        OverworldType m_overworldType = OverworldType.First;

        ExploreType[,] m_exploredCells = new ExploreType[8, 16];
        ShopType[,] m_shopCells = new ShopType[8, 16];
        ShopType m_shopFilter = ShopType.All;

        int m_activeRow;
        int m_activeColumn;

        bool m_hasCandle;
        bool m_hasArrow;
        bool m_hasFood;
        bool m_hasRing;
        bool m_hasKey;

        PictureBox m_unexploredPictureBox;
        PictureBox m_exploredPictureBox;
    }
}
