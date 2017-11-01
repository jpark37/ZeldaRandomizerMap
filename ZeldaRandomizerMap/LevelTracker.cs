using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaRandomizerMap
{
    enum RoomType
    {
        Pending,
        Clear,
        StairsA,
        StairsB,
        StairsC,
        StairsD,
        StairsE,
        StairsF,
        StairsX,
        Solid,
        NearPatra,
        NearGanon,
        Ganon,
        Zelda,
    }

    enum WallType
    {
        None,
        Pending,
        Clear,
        Solid,
        Key,
        Shutter,
    }

    class LevelTracker
    {
        public LevelTracker(PictureBox[,] roomPictureBoxesAll, PictureBox[,] roomPictureBoxes, PictureBox[,] verticalPictureBoxesAll, PictureBox[,] verticalPictureBoxes, PictureBox[,] horiztonalPictureBoxesAll, PictureBox[,] horiztonalPictureBoxes)
        {
            m_roomPictureBoxesAll = roomPictureBoxesAll;
            m_roomPictureBoxes = roomPictureBoxes;
            m_verticalPictureBoxesAll = verticalPictureBoxesAll;
            m_verticalPictureBoxes = verticalPictureBoxes;
            m_horizontalPictureBoxesAll = horiztonalPictureBoxesAll;
            m_horizontalPictureBoxes = horiztonalPictureBoxes;
        }

        public void UpdateRoom(int row, int column)
        {
            if (m_roomPictureBoxes[row, column] == null)
            {
                m_roomPictureBoxesAll[row, column].Image = null;
            }
            else
            {
                switch (m_levelRooms[row, column])
                {
                    case RoomType.Pending:
                        m_roomPictureBoxes[row, column].Image = ImageConstants.PendingRoomBitmap;
                        break;
                    case RoomType.Clear:
                        m_roomPictureBoxes[row, column].Image = ImageConstants.ClearRoomBitmap;
                        break;
                    case RoomType.StairsA:
                        m_roomPictureBoxes[row, column].Image = ImageConstants.StairsRoomBitmapA;
                        break;
                    case RoomType.StairsB:
                        m_roomPictureBoxes[row, column].Image = ImageConstants.StairsRoomBitmapB;
                        break;
                    case RoomType.StairsC:
                        m_roomPictureBoxes[row, column].Image = ImageConstants.StairsRoomBitmapC;
                        break;
                    case RoomType.StairsD:
                        m_roomPictureBoxes[row, column].Image = ImageConstants.StairsRoomBitmapD;
                        break;
                    case RoomType.StairsE:
                        m_roomPictureBoxes[row, column].Image = ImageConstants.StairsRoomBitmapE;
                        break;
                    case RoomType.StairsF:
                        m_roomPictureBoxes[row, column].Image = ImageConstants.StairsRoomBitmapF;
                        break;
                    case RoomType.StairsX:
                        m_roomPictureBoxes[row, column].Image = ImageConstants.StairsRoomBitmapX;
                        break;
                    case RoomType.Solid:
                        m_roomPictureBoxes[row, column].Image = ImageConstants.SolidRoomBitmap;
                        break;
                    case RoomType.NearPatra:
                        m_roomPictureBoxes[row, column].Image = ImageConstants.NearPatraRoomBitmap;
                        break;
                    case RoomType.NearGanon:
                        m_roomPictureBoxes[row, column].Image = ImageConstants.NearGanonRoomBitmap;
                        break;
                    case RoomType.Ganon:
                        m_roomPictureBoxes[row, column].Image = ImageConstants.GanonRoomBitmap;
                        break;
                    case RoomType.Zelda:
                        m_roomPictureBoxes[row, column].Image = ImageConstants.ZeldaRoomBitmap;
                        break;
                }
            }
        }

        public void SelectRoom(int row, int column)
        {
            m_levelRow = row;
            m_levelColumn = column;
            switch (m_levelRooms[row, column])
            {
                case RoomType.Pending:
                case RoomType.NearPatra:
                    m_levelRooms[row, column] = RoomType.Clear;
                    UpdateRoom(row, column);
                    UnsetRoomNearPatraHelper(m_levelRow - 1, m_levelColumn);
                    UnsetRoomNearPatraHelper(m_levelRow, m_levelColumn - 1);
                    UnsetRoomNearPatraHelper(m_levelRow, m_levelColumn + 1);
                    UnsetRoomNearPatraHelper(m_levelRow + 1, m_levelColumn);
                    break;
            }
        }

        public void SetRoomPending()
        {
            m_levelRooms[m_levelRow, m_levelColumn] = RoomType.Pending;
            UpdateRoom(m_levelRow, m_levelColumn);
        }

        public void SetRoomClear()
        {
            m_levelRooms[m_levelRow, m_levelColumn] = RoomType.Clear;
            UpdateRoom(m_levelRow, m_levelColumn);
        }

        public void SetRoomStairsA()
        {
            m_levelRooms[m_levelRow, m_levelColumn] = RoomType.StairsA;
            UpdateRoom(m_levelRow, m_levelColumn);
        }

        public void SetRoomStairsB()
        {
            m_levelRooms[m_levelRow, m_levelColumn] = RoomType.StairsB;
            UpdateRoom(m_levelRow, m_levelColumn);
        }

        public void SetRoomStairsC()
        {
            m_levelRooms[m_levelRow, m_levelColumn] = RoomType.StairsC;
            UpdateRoom(m_levelRow, m_levelColumn);
        }

        public void SetRoomStairsD()
        {
            m_levelRooms[m_levelRow, m_levelColumn] = RoomType.StairsD;
            UpdateRoom(m_levelRow, m_levelColumn);
        }

        public void SetRoomStairsE()
        {
            m_levelRooms[m_levelRow, m_levelColumn] = RoomType.StairsE;
            UpdateRoom(m_levelRow, m_levelColumn);
        }

        public void SetRoomStairsF()
        {
            m_levelRooms[m_levelRow, m_levelColumn] = RoomType.StairsF;
            UpdateRoom(m_levelRow, m_levelColumn);
        }

        public void SetRoomStairsUnknown()
        {
            m_levelRooms[m_levelRow, m_levelColumn] = RoomType.StairsX;
            UpdateRoom(m_levelRow, m_levelColumn);
        }

        public void SetRoomSolid()
        {
            m_levelRooms[m_levelRow, m_levelColumn] = RoomType.Solid;
            UpdateRoom(m_levelRow, m_levelColumn);
            if (m_levelRow < 8)
            {
                if (m_levelColumn > 0)
                {
                    m_horizontalPictureBoxes[m_levelRow, m_levelColumn - 1].Image = ImageConstants.SolidWallBitmap;
                }
                if (m_levelColumn < 7)
                {
                    m_horizontalPictureBoxes[m_levelRow, m_levelColumn].Image = ImageConstants.SolidWallBitmap;
                }
            }
            if (m_levelColumn < 8)
            {
                if (m_levelRow > 0)
                {
                    m_verticalPictureBoxes[m_levelRow - 1, m_levelColumn].Image = ImageConstants.SolidWallBitmap;
                }
                if (m_levelRow < 7)
                {
                    m_verticalPictureBoxes[m_levelRow, m_levelColumn].Image = ImageConstants.SolidWallBitmap;
                }
            }
        }

        public void SetRoomNearPatra()
        {
            SetRoomNearPatraHelper(m_levelRow - 1, m_levelColumn);
            SetRoomNearPatraHelper(m_levelRow, m_levelColumn - 1);
            SetRoomNearPatraHelper(m_levelRow, m_levelColumn + 1);
            SetRoomNearPatraHelper(m_levelRow + 1, m_levelColumn);
        }

        public void SetRoomNearGanon()
        {
            m_levelRooms[m_levelRow, m_levelColumn] = RoomType.NearGanon;
            UpdateRoom(m_levelRow, m_levelColumn);
        }

        public void SetRoomGanon()
        {
            m_levelRooms[m_levelRow, m_levelColumn] = RoomType.Ganon;
            UpdateRoom(m_levelRow, m_levelColumn);
        }

        public void SetRoomZelda()
        {
            m_levelRooms[m_levelRow, m_levelColumn] = RoomType.Zelda;
            UpdateRoom(m_levelRow, m_levelColumn);
        }

        public void UpdateVertical(int row, int column)
        {
            if (m_verticalPictureBoxes[row, column] == null)
            {
                m_verticalPictureBoxesAll[row, column].Image = null;
            }
            else
            {
                switch (m_levelVerticalWalls[row, column])
                {
                    case WallType.Pending:
                        m_verticalPictureBoxes[row, column].Image = ImageConstants.PendingWallBitmap;
                        break;
                    case WallType.Clear:
                        m_verticalPictureBoxes[row, column].Image = ImageConstants.ClearWallBitmap;
                        break;
                    case WallType.Solid:
                        m_verticalPictureBoxes[row, column].Image = ImageConstants.SolidWallBitmap;
                        break;
                    case WallType.Key:
                        m_verticalPictureBoxes[row, column].Image = ImageConstants.KeyWallBitmap;
                        break;
                    case WallType.Shutter:
                        m_verticalPictureBoxes[row, column].Image = ImageConstants.ShutterWallBitmap;
                        break;
                }
            }
        }

        public void ToggleVertical(int row, int column)
        {
            switch (m_levelVerticalWalls[row, column])
            {
                case WallType.Pending:
                    m_levelVerticalWalls[row, column] = WallType.Clear;
                    break;
                case WallType.Clear:
                    m_levelVerticalWalls[row, column] = WallType.Solid;
                    break;
                case WallType.Solid:
                    m_levelVerticalWalls[row, column] = WallType.Key;
                    break;
                case WallType.Key:
                    m_levelVerticalWalls[row, column] = WallType.Shutter;
                    break;
                case WallType.Shutter:
                    m_levelVerticalWalls[row, column] = WallType.Pending;
                    break;
            }

            UpdateVertical(row, column);
        }

        public void UpdateHorizontal(int row, int column)
        {
            if (m_horizontalPictureBoxes[row, column] == null)
            {
                m_horizontalPictureBoxesAll[row, column].Image = null;
            }
            else
            {
                switch (m_levelHorizontalWalls[row, column])
                {
                    case WallType.Pending:
                        m_horizontalPictureBoxes[row, column].Image = ImageConstants.PendingWallBitmap;
                        break;
                    case WallType.Clear:
                        m_horizontalPictureBoxes[row, column].Image = ImageConstants.ClearWallBitmap;
                        break;
                    case WallType.Solid:
                        m_horizontalPictureBoxes[row, column].Image = ImageConstants.SolidWallBitmap;
                        break;
                    case WallType.Key:
                        m_horizontalPictureBoxes[row, column].Image = ImageConstants.KeyWallBitmap;
                        break;
                    case WallType.Shutter:
                        m_horizontalPictureBoxes[row, column].Image = ImageConstants.ShutterWallBitmap;
                        break;
                }
            }
        }

        public void ToggleHorizontal(int row, int column)
        {
            switch (m_levelHorizontalWalls[row, column])
            {
                case WallType.Pending:
                    m_levelHorizontalWalls[row, column] = WallType.Clear;
                    break;
                case WallType.Clear:
                    m_levelHorizontalWalls[row, column] = WallType.Solid;
                    break;
                case WallType.Solid:
                    m_levelHorizontalWalls[row, column] = WallType.Key;
                    break;
                case WallType.Key:
                    m_levelHorizontalWalls[row, column] = WallType.Shutter;
                    break;
                case WallType.Shutter:
                    m_levelHorizontalWalls[row, column] = WallType.Pending;
                    break;
            }

            UpdateHorizontal(row, column);
        }

        private bool IsRoomPreviouslyVisited(int row, int column)
        {
            bool visited = false;

            if (m_levelRow != row || m_levelColumn != column)
            {
                int rowCount = m_levelRooms.GetLength(0);
                int columnCount = m_levelRooms.GetLength(1);
                if (row >= 0 && row < rowCount && column >= 0 && column < columnCount)
                {
                    switch (m_levelRooms[row, column])
                    {
                        case RoomType.Clear:
                        case RoomType.StairsA:
                        case RoomType.StairsB:
                        case RoomType.StairsC:
                        case RoomType.StairsD:
                        case RoomType.StairsE:
                        case RoomType.StairsF:
                        case RoomType.StairsX:
                        case RoomType.NearGanon:
                            visited = true;
                            break;
                    }
                }
            }

            return visited;
        }

        private void SetRoomNearPatraHelper(int row, int column)
        {
            int rowCount = m_levelRooms.GetLength(0);
            int columnCount = m_levelRooms.GetLength(1);
            if (row >= 0 && row < rowCount && column >= 0 && column < columnCount)
            {
                if (m_levelRooms[row, column] == RoomType.Pending)
                {
                    if (!IsRoomPreviouslyVisited(row, column - 1) &&
                        !IsRoomPreviouslyVisited(row, column + 1) &&
                        !IsRoomPreviouslyVisited(row - 1, column) &&
                        !IsRoomPreviouslyVisited(row + 1, column))
                    {
                        m_levelRooms[row, column] = RoomType.NearPatra;
                        UpdateRoom(row, column);
                    }
                }
            }
        }

        private void UnsetRoomNearPatraHelper(int row, int column)
        {
            int rowCount = m_levelRooms.GetLength(0);
            int columnCount = m_levelRooms.GetLength(1);
            if (row >= 0 && row < rowCount && column >= 0 && column < columnCount)
            {
                if (m_levelRooms[row, column] == RoomType.NearPatra)
                {
                    m_levelRooms[row, column] = RoomType.Pending;
                    UpdateRoom(row, column);
                }
            }
        }

        private static RoomType[,] InitializeRooms()
        {
            RoomType[,] rooms = new RoomType[8, 8];
            for (int row = 0; row < 8; ++row)
            {
                for (int column = 0; column < 8; ++column)
                {
                    rooms[row, column] = RoomType.Pending;
                }
            }
            return rooms;
        }

        private static WallType[,] InitializeVerticals()
        {
            WallType[,] verticals = new WallType[7, 8];
            for (int row = 0; row < 7; ++row)
            {
                for (int column = 0; column < 8; ++column)
                {
                    verticals[row, column] = WallType.Pending;
                }
            }
            return verticals;
        }

        private static WallType[,] InitializeHorizontals()
        {
            WallType[,] horizontals = new WallType[8, 7];
            for (int row = 0; row < 8; ++row)
            {
                for (int column = 0; column < 7; ++column)
                {
                    horizontals[row, column] = WallType.Pending;
                }
            }
            return horizontals;
        }

        RoomType[,] m_levelRooms = InitializeRooms();
        WallType[,] m_levelVerticalWalls = InitializeVerticals();
        WallType[,] m_levelHorizontalWalls = InitializeHorizontals();

        PictureBox[,] m_roomPictureBoxesAll;
        PictureBox[,] m_roomPictureBoxes;
        PictureBox[,] m_verticalPictureBoxesAll;
        PictureBox[,] m_verticalPictureBoxes;
        PictureBox[,] m_horizontalPictureBoxesAll;
        PictureBox[,] m_horizontalPictureBoxes;

        int m_levelRow;
        int m_levelColumn;
    }
}
