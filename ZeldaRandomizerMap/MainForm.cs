using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaRandomizerMap
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            m_overworldTracker = new OverworldTracker(unexploredPictureBox, exploredPictureBox);
            m_levelTrackers = InitializeLevelTrackers();

            m_levelTrackers[8].SelectRoom(7, 6);
            m_levelTrackers[8].ToggleVertical(6, 6);
            m_levelTrackers[8].SelectRoom(6, 6);

            m_levelTrackers[9].ToggleHorizontal(7, 5);
            m_levelTrackers[9].ToggleHorizontal(7, 5);
            m_levelTrackers[9].ToggleHorizontal(7, 6);
            m_levelTrackers[9].ToggleHorizontal(7, 6);
            m_levelTrackers[9].SelectRoom(7, 6);
            m_levelTrackers[9].ToggleVertical(6, 6);
            m_levelTrackers[9].SelectRoom(6, 6);

            RefreshLevelsTab(9);
        }

        private LevelTracker[] InitializeLevelTrackers()
        {
            PictureBox[,] roomPictureBoxesAll = new PictureBox[,]
            {
                { levelRoom0,  levelRoom1,  levelRoom2,  levelRoom3,  levelRoom4,  levelRoom5,  levelRoom6,  levelRoom7 },
                { levelRoom8,  levelRoom9,  levelRoom10, levelRoom11, levelRoom12, levelRoom13, levelRoom14, levelRoom15 },
                { levelRoom16, levelRoom17, levelRoom18, levelRoom19, levelRoom20, levelRoom21, levelRoom22, levelRoom23 },
                { levelRoom24, levelRoom25, levelRoom26, levelRoom27, levelRoom28, levelRoom29, levelRoom30, levelRoom31 },
                { levelRoom32, levelRoom33, levelRoom34, levelRoom35, levelRoom36, levelRoom37, levelRoom38, levelRoom39 },
                { levelRoom40, levelRoom41, levelRoom42, levelRoom43, levelRoom44, levelRoom45, levelRoom46, levelRoom47 },
                { levelRoom48, levelRoom49, levelRoom50, levelRoom51, levelRoom52, levelRoom53, levelRoom54, levelRoom55 },
                { levelRoom56, levelRoom57, levelRoom58, levelRoom59, levelRoom60, levelRoom61, levelRoom62, levelRoom63 },
            };

            PictureBox[,] roomPictureBoxes1 = new PictureBox[,]
            {
                { null, null,        null,        null,        null,        null,        null,        null },
                { null, null,        null,        null,        null,        null,        null,        null },
                { null, null,        levelRoom18, levelRoom19, null,        null,        null,        null },
                { null, null,        null,        levelRoom27, null,        levelRoom29, levelRoom30, null },
                { null, levelRoom33, levelRoom34, levelRoom35, levelRoom36, levelRoom37, null,        null },
                { null, null,        levelRoom42, levelRoom43, levelRoom44, null,        null,        null },
                { null, null,        null,        levelRoom51, null,        null,        null,        null },
                { null, null,        levelRoom58, levelRoom59, levelRoom60, null,        null,        null },
            };

            PictureBox[,] roomPictureBoxes2 = new PictureBox[,]
            {
                { null, null, null,        levelRoom3,  levelRoom4,  null,        null, null },
                { null, null, null,        null,        levelRoom12, levelRoom13, null, null },
                { null, null, null,        null,        levelRoom20, levelRoom21, null, null },
                { null, null, null,        null,        levelRoom28, levelRoom29, null, null },
                { null, null, null,        null,        levelRoom36, levelRoom37, null, null },
                { null, null, null,        null,        levelRoom44, levelRoom45, null, null },
                { null, null, levelRoom50, levelRoom51, levelRoom52, levelRoom53, null, null },
                { null, null, null,        levelRoom59, levelRoom60, null,        null, null },
            };

            PictureBox[,] roomPictureBoxes3 = new PictureBox[,]
            {
                { null, null,        null,        null,        null,        null,        null, null },
                { null, null,        null,        null,        null,        null,        null, null },
                { null, null,        levelRoom18, levelRoom19, null,        null,        null, null },
                { null, null,        null,        levelRoom27, null,        levelRoom29, null, null },
                { null, levelRoom33, levelRoom34, levelRoom35, levelRoom36, levelRoom37, null, null },
                { null, levelRoom41, levelRoom42, levelRoom43, levelRoom44, levelRoom45, null, null },
                { null, levelRoom49, null,        levelRoom51, null,        null,        null, null },
                { null, null,        null,        levelRoom59, levelRoom60, null,        null, null },
            };

            PictureBox[,] roomPictureBoxes4 = new PictureBox[,]
            {
                { null, null, levelRoom2,  levelRoom3,  levelRoom4,  levelRoom5,  null, null },
                { null, null, levelRoom10, levelRoom11, levelRoom12, levelRoom13, null, null },
                { null, null, levelRoom18, levelRoom19, null,        null,        null, null },
                { null, null, levelRoom26, levelRoom27, levelRoom28, null,        null, null },
                { null, null, levelRoom34, null,        null,        null,        null, null },
                { null, null, levelRoom42, levelRoom43, null,        null,        null, null },
                { null, null, null,        levelRoom51, levelRoom52, null,        null, null },
                { null, null, levelRoom58, levelRoom59, null,        null,        null, null },
            };

            PictureBox[,] roomPictureBoxes5 = new PictureBox[,]
            {
                { null, null, null,        levelRoom3,  levelRoom4,  null,        null, null },
                { null, null, levelRoom10, levelRoom11, levelRoom12, levelRoom13, null, null },
                { null, null, levelRoom18, levelRoom19, levelRoom20, levelRoom21, null, null },
                { null, null, levelRoom26, null,        null,        levelRoom29, null, null },
                { null, null, null,        null,        levelRoom36, levelRoom37, null, null },
                { null, null, null,        levelRoom43, levelRoom44, levelRoom45, null, null },
                { null, null, levelRoom50, levelRoom51, levelRoom52, levelRoom53, null, null },
                { null, null, null,        null,        levelRoom60, levelRoom61, null, null },
            };

            PictureBox[,] roomPictureBoxes6 = new PictureBox[,]
            {
                { null, null,        levelRoom2,  levelRoom3,  levelRoom4,  levelRoom5,  null,        null },
                { null, levelRoom9,  levelRoom10, levelRoom11, levelRoom12, levelRoom13, levelRoom14, null },
                { null, levelRoom17, levelRoom18, null,        null,        levelRoom21, levelRoom22, null },
                { null, levelRoom25, levelRoom26, levelRoom27, null,        levelRoom29, null,        null },
                { null, levelRoom33, null,        null,        null,        null,        null,        null },
                { null, levelRoom41, null,        null,        null,        null,        null,        null },
                { null, levelRoom49, null,        levelRoom51, null,        null,        null,        null },
                { null, levelRoom57, levelRoom58, levelRoom59, null,        null,        null,        null },
            };

            PictureBox[,] roomPictureBoxes7 = new PictureBox[,]
            {
                { null, levelRoom1,  levelRoom2,  levelRoom3,  levelRoom4,  levelRoom5,  levelRoom6,  null },
                { null, levelRoom9,  levelRoom10, levelRoom11, levelRoom12, levelRoom13, null,        null },
                { null, levelRoom17, levelRoom18, levelRoom19, levelRoom20, null,        null,        null },
                { null, levelRoom25, levelRoom26, levelRoom27, null,        null,        null,        null },
                { null, levelRoom33, levelRoom34, null,        null,        null,        null,        null },
                { null, levelRoom41, levelRoom42, levelRoom43, levelRoom44, null,        null,        null },
                { null, levelRoom49, levelRoom50, levelRoom51, levelRoom52, levelRoom53, levelRoom54, null },
                { null, levelRoom57, levelRoom58, levelRoom59, null,        null,        null,        null },
            };

            PictureBox[,] roomPictureBoxes8 = new PictureBox[,]
            {
                { null,       null,        null,        null,        levelRoom4,  null,        null, null },
                { null,       null,        null,        levelRoom11, levelRoom12, levelRoom13, null, null },
                { null,       null,        levelRoom18, levelRoom19, levelRoom20, null,        null, null },
                { null,       levelRoom25, levelRoom26, levelRoom27, levelRoom28, levelRoom29, null, null },
                { null,       levelRoom33, levelRoom34, levelRoom35, levelRoom36, null,        null, null },
                { null,       null,        levelRoom42, levelRoom43, levelRoom44, levelRoom45, null, null },
                { null,       null,        null,        null,        levelRoom52, null,        null, null },
                { null,       null,        levelRoom58, levelRoom59, levelRoom60, levelRoom61, null, null },
            };

            PictureBox[,] roomPictureBoxes9 = new PictureBox[,]
            {
                { null,        levelRoom1,  levelRoom2,  levelRoom3,  levelRoom4,  levelRoom5,  levelRoom6,  levelRoom7 },
                { levelRoom8,  levelRoom9,  levelRoom10, levelRoom11, levelRoom12, levelRoom13, levelRoom14, levelRoom15 },
                { levelRoom16, levelRoom17, levelRoom18, levelRoom19, levelRoom20, levelRoom21, levelRoom22, levelRoom23 },
                { levelRoom24, levelRoom25, levelRoom26, levelRoom27, levelRoom28, levelRoom29, levelRoom30, levelRoom31 },
                { levelRoom32, levelRoom33, levelRoom34, levelRoom35, levelRoom36, levelRoom37, levelRoom38, levelRoom39 },
                { levelRoom40, levelRoom41, levelRoom42, levelRoom43, levelRoom44, levelRoom45, levelRoom46, levelRoom47 },
                { null,        levelRoom49, levelRoom50, levelRoom51, levelRoom52, levelRoom53, levelRoom54, null },
                { null,        levelRoom57, null,        levelRoom59, levelRoom60, null,        levelRoom62, null },
            };

            PictureBox[,] verticalPictureBoxesAll = new PictureBox[,]
            {
                { levelVerticalWall0,  levelVerticalWall1,  levelVerticalWall2,  levelVerticalWall3,  levelVerticalWall4,  levelVerticalWall5,  levelVerticalWall6,  levelVerticalWall7 },
                { levelVerticalWall8,  levelVerticalWall9,  levelVerticalWall10, levelVerticalWall11, levelVerticalWall12, levelVerticalWall13, levelVerticalWall14, levelVerticalWall15 },
                { levelVerticalWall16, levelVerticalWall17, levelVerticalWall18, levelVerticalWall19, levelVerticalWall20, levelVerticalWall21, levelVerticalWall22, levelVerticalWall23 },
                { levelVerticalWall24, levelVerticalWall25, levelVerticalWall26, levelVerticalWall27, levelVerticalWall28, levelVerticalWall29, levelVerticalWall30, levelVerticalWall31 },
                { levelVerticalWall32, levelVerticalWall33, levelVerticalWall34, levelVerticalWall35, levelVerticalWall36, levelVerticalWall37, levelVerticalWall38, levelVerticalWall39 },
                { levelVerticalWall40, levelVerticalWall41, levelVerticalWall42, levelVerticalWall43, levelVerticalWall44, levelVerticalWall45, levelVerticalWall46, levelVerticalWall47 },
                { levelVerticalWall48, levelVerticalWall49, levelVerticalWall50, levelVerticalWall51, levelVerticalWall52, levelVerticalWall53, levelVerticalWall54, levelVerticalWall55 },
            };

            PictureBox[,] verticalPictureBoxes1 = new PictureBox[,]
            {
                { null, null,           null,                null,                null,                null,                null, null },
                { null, null,           null,                null,                null,                null,                null, null },
                { null, null,           null,                levelVerticalWall19, null,                null,                null, null },
                { null, null,           null,                levelVerticalWall27, null,                levelVerticalWall29, null, null },
                { null, null,           levelVerticalWall34, levelVerticalWall35, levelVerticalWall36, null,                null, null },
                { null, null,           null,                levelVerticalWall43, null,                null,                null, null },
                { null, null,           null,                levelVerticalWall51, null,                null,                null, null },
            };

            PictureBox[,] verticalPictureBoxes2 = new PictureBox[,]
            {
                { null, null, null,           null,                levelVerticalWall4,  null,                null, null },
                { null, null, null,           null,                levelVerticalWall12, levelVerticalWall13, null, null },
                { null, null, null,           null,                levelVerticalWall20, levelVerticalWall21, null, null },
                { null, null, null,           null,                levelVerticalWall28, levelVerticalWall29, null, null },
                { null, null, null,           null,                levelVerticalWall36, levelVerticalWall37, null, null },
                { null, null, null,           null,                levelVerticalWall44, levelVerticalWall45, null, null },
                { null, null, null,           levelVerticalWall51, levelVerticalWall52, null,                null, null },
            };

            PictureBox[,] verticalPictureBoxes3 = new PictureBox[,]
            {
                { null, null,                null,                null,                null,                null,                null, null },
                { null, null,                null,                null,                null,                null,                null, null },
                { null, null,                null,                levelVerticalWall19, null,                null,                null, null },
                { null, null,                null,                levelVerticalWall27, null,                levelVerticalWall29, null, null },
                { null, levelVerticalWall33, levelVerticalWall34, levelVerticalWall35, levelVerticalWall36, levelVerticalWall37, null, null },
                { null, levelVerticalWall41, null,                levelVerticalWall43, null,                null,                null, null },
                { null, null,                null,                levelVerticalWall51, null,                null,                null, null },
            };

            PictureBox[,] verticalPictureBoxes4 = new PictureBox[,]
            {
                { null, null, levelVerticalWall2,  levelVerticalWall3,  levelVerticalWall4,  levelVerticalWall5,  null, null },
                { null, null, levelVerticalWall10, levelVerticalWall11, null,                null,                null, null },
                { null, null, levelVerticalWall18, levelVerticalWall19, null,                null,                null, null },
                { null, null, levelVerticalWall26, null,                null,                null,                null, null },
                { null, null, levelVerticalWall34, null,                null,                null,                null, null },
                { null, null, null,                levelVerticalWall43, null,                null,                null, null },
                { null, null, null,                levelVerticalWall51, null,                null,                null, null },
            };

            PictureBox[,] verticalPictureBoxes5 = new PictureBox[,]
            {
                { null, null, null,                levelVerticalWall3,  levelVerticalWall4,  null,                null, null },
                { null, null, levelVerticalWall10, levelVerticalWall11, levelVerticalWall12, levelVerticalWall13, null, null },
                { null, null, levelVerticalWall18, null,                null,                levelVerticalWall21, null, null },
                { null, null, null,                null,                null,                levelVerticalWall29, null, null },
                { null, null, null,                null,                levelVerticalWall36, levelVerticalWall37, null, null },
                { null, null, null,                levelVerticalWall43, levelVerticalWall44, levelVerticalWall45, null, null },
                { null, null, null,                null,                levelVerticalWall52, levelVerticalWall53, null, null },
            };

            PictureBox[,] verticalPictureBoxes6 = new PictureBox[,]
            {
                { null, null,                levelVerticalWall2,  levelVerticalWall3,  levelVerticalWall4,  levelVerticalWall5,  null,                null },
                { null, levelVerticalWall9,  levelVerticalWall10, null,                null,                levelVerticalWall13, levelVerticalWall14, null },
                { null, levelVerticalWall17, levelVerticalWall18, null,                null,                levelVerticalWall21, null,                null },
                { null, levelVerticalWall25, null,                null,                null,                null,                null,                null },
                { null, levelVerticalWall33, null,                null,                null,                null,                null,                null },
                { null, levelVerticalWall41, null,                null,                null,                null,                null,                null },
                { null, levelVerticalWall49, null,                levelVerticalWall51, null,                null,                null,                null },
            };

            PictureBox[,] verticalPictureBoxes7 = new PictureBox[,]
            {
                { null, levelVerticalWall1,  levelVerticalWall2,  levelVerticalWall3,  levelVerticalWall4,  levelVerticalWall5,  null,           null },
                { null, levelVerticalWall9,  levelVerticalWall10, levelVerticalWall11, levelVerticalWall12, null,                null,           null },
                { null, levelVerticalWall17, levelVerticalWall18, levelVerticalWall19, null,                null,                null,           null },
                { null, levelVerticalWall25, levelVerticalWall26, null,                null,                null,                null,           null },
                { null, levelVerticalWall33, levelVerticalWall34, null,                null,                null,                null,           null },
                { null, levelVerticalWall41, levelVerticalWall42, levelVerticalWall43, levelVerticalWall44, null,                null,           null },
                { null, levelVerticalWall49, levelVerticalWall50, levelVerticalWall51, null,                null,                null,           null },
            };

            PictureBox[,] verticalPictureBoxes8 = new PictureBox[,]
            {
                { null, null,                null,                null,                levelVerticalWall4,  null, null, null },
                { null, null,                null,                levelVerticalWall11, levelVerticalWall12, null, null, null },
                { null, null,                levelVerticalWall18, levelVerticalWall19, levelVerticalWall20, null, null, null },
                { null, levelVerticalWall25, levelVerticalWall26, levelVerticalWall27, levelVerticalWall28, null, null, null },
                { null, null,                levelVerticalWall34, levelVerticalWall35, levelVerticalWall36, null, null, null },
                { null, null,                null,                null,                levelVerticalWall44, null, null, null },
                { null, null,                null,                null,                levelVerticalWall52, null, null, null },
            };

            PictureBox[,] verticalPictureBoxes9 = new PictureBox[,]
            {
                { null,                levelVerticalWall1,  levelVerticalWall2,  levelVerticalWall3,  levelVerticalWall4,  levelVerticalWall5,  levelVerticalWall6,  levelVerticalWall7 },
                { levelVerticalWall8,  levelVerticalWall9,  levelVerticalWall10, levelVerticalWall11, levelVerticalWall12, levelVerticalWall13, levelVerticalWall14, levelVerticalWall15 },
                { levelVerticalWall16, levelVerticalWall17, levelVerticalWall18, levelVerticalWall19, levelVerticalWall20, levelVerticalWall21, levelVerticalWall22, levelVerticalWall23 },
                { levelVerticalWall24, levelVerticalWall25, levelVerticalWall26, levelVerticalWall27, levelVerticalWall28, levelVerticalWall29, levelVerticalWall30, levelVerticalWall31 },
                { levelVerticalWall32, levelVerticalWall33, levelVerticalWall34, levelVerticalWall35, levelVerticalWall36, levelVerticalWall37, levelVerticalWall38, levelVerticalWall39 },
                { null,                levelVerticalWall41, levelVerticalWall42, levelVerticalWall43, levelVerticalWall44, levelVerticalWall45, levelVerticalWall46, null },
                { null,                levelVerticalWall49, null,                levelVerticalWall51, levelVerticalWall52, null,                levelVerticalWall54, null },
            };

            PictureBox[,] horizontalPictureBoxesAll = new PictureBox[,]
            {
                { levelHorizontalWall0,  levelHorizontalWall1,  levelHorizontalWall2,  levelHorizontalWall3,  levelHorizontalWall4,  levelHorizontalWall5,  levelHorizontalWall6 },
                { levelHorizontalWall7,  levelHorizontalWall8,  levelHorizontalWall9,  levelHorizontalWall10, levelHorizontalWall11, levelHorizontalWall12, levelHorizontalWall13 },
                { levelHorizontalWall14, levelHorizontalWall15, levelHorizontalWall16, levelHorizontalWall17, levelHorizontalWall18, levelHorizontalWall19, levelHorizontalWall20 },
                { levelHorizontalWall21, levelHorizontalWall22, levelHorizontalWall23, levelHorizontalWall24, levelHorizontalWall25, levelHorizontalWall26, levelHorizontalWall27 },
                { levelHorizontalWall28, levelHorizontalWall29, levelHorizontalWall30, levelHorizontalWall31, levelHorizontalWall32, levelHorizontalWall33, levelHorizontalWall34 },
                { levelHorizontalWall35, levelHorizontalWall36, levelHorizontalWall37, levelHorizontalWall38, levelHorizontalWall39, levelHorizontalWall40, levelHorizontalWall41 },
                { levelHorizontalWall42, levelHorizontalWall43, levelHorizontalWall44, levelHorizontalWall45, levelHorizontalWall46, levelHorizontalWall47, levelHorizontalWall48 },
                { levelHorizontalWall49, levelHorizontalWall50, levelHorizontalWall51, levelHorizontalWall52, levelHorizontalWall53, levelHorizontalWall54, levelHorizontalWall55 },
            };

            PictureBox[,] horizontalPictureBoxes1 = new PictureBox[,]
            {
                { null, null,                  null,                  null,                  null,                  null,                  null },
                { null, null,                  null,                  null,                  null,                  null,                  null },
                { null, null,                  levelHorizontalWall16, null,                  null,                  null,                  null },
                { null, null,                  null,                  null,                  null,                  levelHorizontalWall26, null },
                { null, levelHorizontalWall29, levelHorizontalWall30, levelHorizontalWall31, levelHorizontalWall32, null,                  null },
                { null, null,                  levelHorizontalWall37, levelHorizontalWall38, null,                  null,                  null },
                { null, null,                  null,                  null,                  null,                  null,                  null },
                { null, null,                  levelHorizontalWall51, levelHorizontalWall52, null,                  null,                  null },
            };

            PictureBox[,] horizontalPictureBoxes2 = new PictureBox[,]
            {
                { null, null, null,                  levelHorizontalWall3,  null,                  null, null },
                { null, null, null,                  null,                  levelHorizontalWall11, null, null },
                { null, null, null,                  null,                  levelHorizontalWall18, null, null },
                { null, null, null,                  null,                  levelHorizontalWall25, null, null },
                { null, null, null,                  null,                  levelHorizontalWall32, null, null },
                { null, null, null,                  null,                  levelHorizontalWall39, null, null },
                { null, null, levelHorizontalWall44, levelHorizontalWall45, levelHorizontalWall46, null, null },
                { null, null, null,                  levelHorizontalWall52, null,                  null, null },
            };

            PictureBox[,] horizontalPictureBoxes3 = new PictureBox[,]
            {
                { null, null,                  null,                  null,                  null,                  null, null },
                { null, null,                  null,                  null,                  null,                  null, null },
                { null, null,                  levelHorizontalWall16, null,                  null,                  null, null },
                { null, null,                  null,                  null,                  null,                  null, null },
                { null, levelHorizontalWall29, levelHorizontalWall30, levelHorizontalWall31, levelHorizontalWall32, null, null },
                { null, levelHorizontalWall36, levelHorizontalWall37, levelHorizontalWall38, levelHorizontalWall39, null, null },
                { null, null,                  null,                  null,                  null,                  null, null },
                { null, null,                  null,                  levelHorizontalWall52, null,                  null, null },
            };

            PictureBox[,] horizontalPictureBoxes4 = new PictureBox[,]
            {
                { null, null, levelHorizontalWall2,  levelHorizontalWall3,  levelHorizontalWall4,  null, null },
                { null, null, levelHorizontalWall9,  levelHorizontalWall10, levelHorizontalWall11, null, null },
                { null, null, levelHorizontalWall16, null,                  null,                  null, null },
                { null, null, levelHorizontalWall23, levelHorizontalWall24, null,                  null, null },
                { null, null, null,                  null,                  null,                  null, null },
                { null, null, levelHorizontalWall37, null,                  null,                  null, null },
                { null, null, null,                  levelHorizontalWall45, null,                  null, null },
                { null, null, levelHorizontalWall51, null,                  null,                  null, null },
            };

            PictureBox[,] horizontalPictureBoxes5 = new PictureBox[,]
            {
                { null, null, null,                  levelHorizontalWall3,  null,                  null, null },
                { null, null, levelHorizontalWall9,  levelHorizontalWall10, levelHorizontalWall11, null, null },
                { null, null, levelHorizontalWall16, levelHorizontalWall17, levelHorizontalWall18, null, null },
                { null, null, null,                  null,                  null,                  null, null },
                { null, null, null,                  null,                  levelHorizontalWall32, null, null },
                { null, null, null,                  levelHorizontalWall38, levelHorizontalWall39, null, null },
                { null, null, levelHorizontalWall44, levelHorizontalWall45, levelHorizontalWall46, null, null },
                { null, null, null,                  null,                  levelHorizontalWall53, null, null },
            };

            PictureBox[,] horizontalPictureBoxes6 = new PictureBox[,]
            {
                { null, null,                  levelHorizontalWall2,  levelHorizontalWall3,  levelHorizontalWall4,  null,                  null },
                { null, levelHorizontalWall8,  levelHorizontalWall9,  levelHorizontalWall10, levelHorizontalWall11, levelHorizontalWall12, null },
                { null, levelHorizontalWall15, null,                  null,                  null,                  levelHorizontalWall19, null },
                { null, levelHorizontalWall22, levelHorizontalWall23, null,                  null,                  null,                  null },
                { null, null,                  null,                  null,                  null,                  null,                  null },
                { null, null,                  null,                  null,                  null,                  null,                  null },
                { null, null,                  null,                  null,                  null,                  null,                  null },
                { null, levelHorizontalWall50, levelHorizontalWall51, null,                  null,                  null,                  null },
            };

            PictureBox[,] horizontalPictureBoxes7 = new PictureBox[,]
            {
                { null, levelHorizontalWall1,  levelHorizontalWall2,  levelHorizontalWall3,  levelHorizontalWall4,  levelHorizontalWall5,  null },
                { null, levelHorizontalWall8,  levelHorizontalWall9,  levelHorizontalWall10, levelHorizontalWall11, null,                  null },
                { null, levelHorizontalWall15, levelHorizontalWall16, levelHorizontalWall17, null,                  null,                  null },
                { null, levelHorizontalWall22, levelHorizontalWall23, null,                  null,                  null,                  null },
                { null, levelHorizontalWall29, null,                  null,                  null,                  null,                  null },
                { null, levelHorizontalWall36, levelHorizontalWall37, levelHorizontalWall38, null,                  null,                  null },
                { null, levelHorizontalWall43, levelHorizontalWall44, levelHorizontalWall45, levelHorizontalWall46, levelHorizontalWall47, null },
                { null, levelHorizontalWall50, levelHorizontalWall51, null,                  null,                  null,                  null },
            };

            PictureBox[,] horizontalPictureBoxes8 = new PictureBox[,]
            {
                { null, null,                  null,                  null,                  null,                  null, null },
                { null, null,                  null,                  levelHorizontalWall10, levelHorizontalWall11, null, null },
                { null, null,                  levelHorizontalWall16, levelHorizontalWall17, null,                  null, null },
                { null, levelHorizontalWall22, levelHorizontalWall23, levelHorizontalWall24, levelHorizontalWall25, null, null },
                { null, levelHorizontalWall29, levelHorizontalWall30, levelHorizontalWall31, null,                  null, null },
                { null, null,                  levelHorizontalWall37, levelHorizontalWall38, levelHorizontalWall39, null, null },
                { null, null,                  null,                  null,                  null,                  null, null },
                { null, null,                  levelHorizontalWall51, levelHorizontalWall52, levelHorizontalWall53, null, null },
            };

            PictureBox[,] horizontalPictureBoxes9 = new PictureBox[,]
            {
                { null,                  levelHorizontalWall1,  levelHorizontalWall2,  levelHorizontalWall3,  levelHorizontalWall4,  levelHorizontalWall5,  levelHorizontalWall6 },
                { levelHorizontalWall7,  levelHorizontalWall8,  levelHorizontalWall9,  levelHorizontalWall10, levelHorizontalWall11, levelHorizontalWall12, levelHorizontalWall13 },
                { levelHorizontalWall14, levelHorizontalWall15, levelHorizontalWall16, levelHorizontalWall17, levelHorizontalWall18, levelHorizontalWall19, levelHorizontalWall20 },
                { levelHorizontalWall21, levelHorizontalWall22, levelHorizontalWall23, levelHorizontalWall24, levelHorizontalWall25, levelHorizontalWall26, levelHorizontalWall27 },
                { levelHorizontalWall28, levelHorizontalWall29, levelHorizontalWall30, levelHorizontalWall31, levelHorizontalWall32, levelHorizontalWall33, levelHorizontalWall34 },
                { levelHorizontalWall35, levelHorizontalWall36, levelHorizontalWall37, levelHorizontalWall38, levelHorizontalWall39, levelHorizontalWall40, levelHorizontalWall41 },
                { null,                  levelHorizontalWall43, levelHorizontalWall44, levelHorizontalWall45, levelHorizontalWall46, levelHorizontalWall47, null },
                { null,                  null,                  null,                  levelHorizontalWall52, null,                  null,                  null },
            };

            return new LevelTracker[]
            {
                new LevelTracker(roomPictureBoxesAll, roomPictureBoxes1, verticalPictureBoxesAll, verticalPictureBoxes1, horizontalPictureBoxesAll, horizontalPictureBoxes1),
                new LevelTracker(roomPictureBoxesAll, roomPictureBoxes2, verticalPictureBoxesAll, verticalPictureBoxes2, horizontalPictureBoxesAll, horizontalPictureBoxes2),
                new LevelTracker(roomPictureBoxesAll, roomPictureBoxes3, verticalPictureBoxesAll, verticalPictureBoxes3, horizontalPictureBoxesAll, horizontalPictureBoxes3),
                new LevelTracker(roomPictureBoxesAll, roomPictureBoxes4, verticalPictureBoxesAll, verticalPictureBoxes4, horizontalPictureBoxesAll, horizontalPictureBoxes4),
                new LevelTracker(roomPictureBoxesAll, roomPictureBoxes5, verticalPictureBoxesAll, verticalPictureBoxes5, horizontalPictureBoxesAll, horizontalPictureBoxes5),
                new LevelTracker(roomPictureBoxesAll, roomPictureBoxes6, verticalPictureBoxesAll, verticalPictureBoxes6, horizontalPictureBoxesAll, horizontalPictureBoxes6),
                new LevelTracker(roomPictureBoxesAll, roomPictureBoxes7, verticalPictureBoxesAll, verticalPictureBoxes7, horizontalPictureBoxesAll, horizontalPictureBoxes7),
                new LevelTracker(roomPictureBoxesAll, roomPictureBoxes8, verticalPictureBoxesAll, verticalPictureBoxes8, horizontalPictureBoxesAll, horizontalPictureBoxes8),
                new LevelTracker(roomPictureBoxesAll, roomPictureBoxes9, verticalPictureBoxesAll, verticalPictureBoxes9, horizontalPictureBoxesAll, horizontalPictureBoxes9),
                new LevelTracker(roomPictureBoxesAll, roomPictureBoxesAll, verticalPictureBoxesAll, verticalPictureBoxesAll, horizontalPictureBoxesAll, horizontalPictureBoxesAll),
            };
        }

        private void SelectRoom(int row, int column)
        {
            m_levelTrackers[m_activeLevelIndex].SelectRoom(row, column);
        }

        private void ToggleVertical(int row, int column)
        {
            m_levelTrackers[m_activeLevelIndex].ToggleVertical(row, column);
        }

        private void ToggleHorizontal(int row, int column)
        {
            m_levelTrackers[m_activeLevelIndex].ToggleHorizontal(row, column);
        }

        void RefreshLevelsTab(int levelIndex)
        {
            m_activeLevelIndex = levelIndex;

            for (int row = 0; row < 8; ++row)
            {
                for (int column = 0; column < 8; ++column)
                {
                    m_levelTrackers[m_activeLevelIndex].UpdateRoom(row, column);
                }
            }
            for (int row = 0; row < 7; ++row)
            {
                for (int column = 0; column < 8; ++column)
                {
                    m_levelTrackers[m_activeLevelIndex].UpdateVertical(row, column);
                }
            }
            for (int row = 0; row < 8; ++row)
            {
                for (int column = 0; column < 7; ++column)
                {
                    m_levelTrackers[m_activeLevelIndex].UpdateHorizontal(row, column);
                }
            }
        }

        private void mapPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            m_overworldTracker.ExploreCell((e.Y * 8) / exploredPictureBox.Height, (e.X * 16) / exploredPictureBox.Width);
        }

        private void exploredPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            m_overworldTracker.SetActiveCell((e.Y * 8) / exploredPictureBox.Height, (e.X * 16) / exploredPictureBox.Width);
        }

        private void l1Button_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteL1();
        }

        private void l2Button_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteL2();
        }

        private void l3Button_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteL3();
        }

        private void l4Button_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteL4();
        }

        private void l5Button_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteL5();
        }

        private void l6Button_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteL6();
        }

        private void l7Button_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteL7();
        }

        private void l8Button_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteL8();
        }

        private void l9Button_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteL9();
        }

        private void levelButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteLevelUnknown();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.ResetCell();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.ClearCell();
        }

        private void levelRoom0_Click(object sender, EventArgs e)
        {
            SelectRoom(0, 0);
        }

        private void levelRoom1_Click(object sender, EventArgs e)
        {
            SelectRoom(0, 1);
        }

        private void levelRoom2_Click(object sender, EventArgs e)
        {
            SelectRoom(0, 2);
        }

        private void levelRoom3_Click(object sender, EventArgs e)
        {
            SelectRoom(0, 3);
        }

        private void levelRoom4_Click(object sender, EventArgs e)
        {
            SelectRoom(0, 4);
        }

        private void levelRoom5_Click(object sender, EventArgs e)
        {
            SelectRoom(0, 5);
        }

        private void levelRoom6_Click(object sender, EventArgs e)
        {
            SelectRoom(0, 6);
        }

        private void levelRoom7_Click(object sender, EventArgs e)
        {
            SelectRoom(0, 7);
        }

        private void levelRoom8_Click(object sender, EventArgs e)
        {
            SelectRoom(1, 0);
        }

        private void levelRoom9_Click(object sender, EventArgs e)
        {
            SelectRoom(1, 1);
        }

        private void levelRoom10_Click(object sender, EventArgs e)
        {
            SelectRoom(1, 2);
        }

        private void levelRoom11_Click(object sender, EventArgs e)
        {
            SelectRoom(1, 3);
        }

        private void levelRoom12_Click(object sender, EventArgs e)
        {
            SelectRoom(1, 4);
        }

        private void levelRoom13_Click(object sender, EventArgs e)
        {
            SelectRoom(1, 5);
        }

        private void levelRoom14_Click(object sender, EventArgs e)
        {
            SelectRoom(1, 6);
        }

        private void levelRoom15_Click(object sender, EventArgs e)
        {
            SelectRoom(1, 7);
        }

        private void levelRoom16_Click(object sender, EventArgs e)
        {
            SelectRoom(2, 0);
        }

        private void levelRoom17_Click(object sender, EventArgs e)
        {
            SelectRoom(2, 1);
        }

        private void levelRoom18_Click(object sender, EventArgs e)
        {
            SelectRoom(2, 2);
        }

        private void levelRoom19_Click(object sender, EventArgs e)
        {
            SelectRoom(2, 3);
        }

        private void levelRoom20_Click(object sender, EventArgs e)
        {
            SelectRoom(2, 4);
        }

        private void levelRoom21_Click(object sender, EventArgs e)
        {
            SelectRoom(2, 5);
        }

        private void levelRoom22_Click(object sender, EventArgs e)
        {
            SelectRoom(2, 6);
        }

        private void levelRoom23_Click(object sender, EventArgs e)
        {
            SelectRoom(2, 7);
        }

        private void levelRoom24_Click(object sender, EventArgs e)
        {
            SelectRoom(3, 0);
        }

        private void levelRoom25_Click(object sender, EventArgs e)
        {
            SelectRoom(3, 1);
        }

        private void levelRoom26_Click(object sender, EventArgs e)
        {
            SelectRoom(3, 2);
        }

        private void levelRoom27_Click(object sender, EventArgs e)
        {
            SelectRoom(3, 3);
        }

        private void levelRoom28_Click(object sender, EventArgs e)
        {
            SelectRoom(3, 4);
        }

        private void levelRoom29_Click(object sender, EventArgs e)
        {
            SelectRoom(3, 5);
        }

        private void levelRoom30_Click(object sender, EventArgs e)
        {
            SelectRoom(3, 6);
        }

        private void levelRoom31_Click(object sender, EventArgs e)
        {
            SelectRoom(3, 7);
        }

        private void levelRoom32_Click(object sender, EventArgs e)
        {
            SelectRoom(4, 0);
        }

        private void levelRoom33_Click(object sender, EventArgs e)
        {
            SelectRoom(4, 1);
        }

        private void levelRoom34_Click(object sender, EventArgs e)
        {
            SelectRoom(4, 2);
        }

        private void levelRoom35_Click(object sender, EventArgs e)
        {
            SelectRoom(4, 3);
        }

        private void levelRoom36_Click(object sender, EventArgs e)
        {
            SelectRoom(4, 4);
        }

        private void levelRoom37_Click(object sender, EventArgs e)
        {
            SelectRoom(4, 5);
        }

        private void levelRoom38_Click(object sender, EventArgs e)
        {
            SelectRoom(4, 6);
        }

        private void levelRoom39_Click(object sender, EventArgs e)
        {
            SelectRoom(4, 7);
        }

        private void levelRoom40_Click(object sender, EventArgs e)
        {
            SelectRoom(5, 0);
        }

        private void levelRoom41_Click(object sender, EventArgs e)
        {
            SelectRoom(5, 1);
        }

        private void levelRoom42_Click(object sender, EventArgs e)
        {
            SelectRoom(5, 2);
        }

        private void levelRoom43_Click(object sender, EventArgs e)
        {
            SelectRoom(5, 3);
        }

        private void levelRoom44_Click(object sender, EventArgs e)
        {
            SelectRoom(5, 4);
        }

        private void levelRoom45_Click(object sender, EventArgs e)
        {
            SelectRoom(5, 5);
        }

        private void levelRoom46_Click(object sender, EventArgs e)
        {
            SelectRoom(5, 6);
        }

        private void levelRoom47_Click(object sender, EventArgs e)
        {
            SelectRoom(5, 7);
        }

        private void levelRoom48_Click(object sender, EventArgs e)
        {
            SelectRoom(6, 0);
        }

        private void levelRoom49_Click(object sender, EventArgs e)
        {
            SelectRoom(6, 1);
        }

        private void levelRoom50_Click(object sender, EventArgs e)
        {
            SelectRoom(6, 2);
        }

        private void levelRoom51_Click(object sender, EventArgs e)
        {
            SelectRoom(6, 3);
        }

        private void levelRoom52_Click(object sender, EventArgs e)
        {
            SelectRoom(6, 4);
        }

        private void levelRoom53_Click(object sender, EventArgs e)
        {
            SelectRoom(6, 5);
        }

        private void levelRoom54_Click(object sender, EventArgs e)
        {
            SelectRoom(6, 6);
        }

        private void levelRoom55_Click(object sender, EventArgs e)
        {
            SelectRoom(6, 7);
        }

        private void levelRoom56_Click(object sender, EventArgs e)
        {
            SelectRoom(7, 0);
        }

        private void levelRoom57_Click(object sender, EventArgs e)
        {
            SelectRoom(7, 1);
        }

        private void levelRoom58_Click(object sender, EventArgs e)
        {
            SelectRoom(7, 2);
        }

        private void levelRoom59_Click(object sender, EventArgs e)
        {
            SelectRoom(7, 3);
        }

        private void levelRoom60_Click(object sender, EventArgs e)
        {
            SelectRoom(7, 4);
        }

        private void levelRoom61_Click(object sender, EventArgs e)
        {
            SelectRoom(7, 5);
        }

        private void levelRoom62_Click(object sender, EventArgs e)
        {
            SelectRoom(7, 6);
        }

        private void levelRoom63_Click(object sender, EventArgs e)
        {
            SelectRoom(7, 7);
        }

        private void resetRoomButton_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeLevelIndex].SetRoomPending();
        }

        private void clearRoomButton_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeLevelIndex].SetRoomClear();
        }

        private void stairsButtonA_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeLevelIndex].SetRoomStairsA();
        }

        private void stairsButtonB_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeLevelIndex].SetRoomStairsB();
        }

        private void stairsButtonC_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeLevelIndex].SetRoomStairsC();
        }

        private void stairsButtonD_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeLevelIndex].SetRoomStairsD();
        }

        private void stairsButtonE_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeLevelIndex].SetRoomStairsE();
        }

        private void stairsButtonF_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeLevelIndex].SetRoomStairsF();
        }

        private void stairsButtonX_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeLevelIndex].SetRoomStairsUnknown();
        }

        private void solidButton_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeLevelIndex].SetRoomSolid();
        }

        private void nearPatraButton_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeLevelIndex].SetRoomNearPatra();
        }

        private void nearGanonButton_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeLevelIndex].SetRoomNearGanon();
        }

        private void ganonButton_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeLevelIndex].SetRoomGanon();
        }

        private void zeldaButton_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeLevelIndex].SetRoomZelda();
        }

        private void levelVerticalWall0_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 0);
        }

        private void levelVerticalWall1_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 1);
        }

        private void levelVerticalWall2_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 2);
        }

        private void levelVerticalWall3_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 3);
        }

        private void levelVerticalWall4_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 4);
        }

        private void levelVerticalWall5_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 5);
        }

        private void levelVerticalWall6_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 6);
        }

        private void levelVerticalWall7_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 7);
        }

        private void levelVerticalWall8_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 0);
        }

        private void levelVerticalWall9_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 1);
        }

        private void levelVerticalWall10_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 2);
        }

        private void levelVerticalWall11_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 3);
        }

        private void levelVerticalWall12_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 4);
        }

        private void levelVerticalWall13_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 5);
        }

        private void levelVerticalWall14_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 6);
        }

        private void levelVerticalWall15_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 7);
        }

        private void levelVerticalWall16_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 0);
        }

        private void levelVerticalWall17_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 1);
        }

        private void levelVerticalWall18_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 2);
        }

        private void levelVerticalWall19_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 3);
        }

        private void levelVerticalWall20_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 4);
        }

        private void levelVerticalWall21_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 5);
        }

        private void levelVerticalWall22_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 6);
        }

        private void levelVerticalWall23_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 7);
        }

        private void levelVerticalWall24_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 0);
        }

        private void levelVerticalWall25_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 1);
        }

        private void levelVerticalWall26_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 2);
        }

        private void levelVerticalWall27_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 3);
        }

        private void levelVerticalWall28_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 4);
        }

        private void levelVerticalWall29_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 5);
        }

        private void levelVerticalWall30_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 6);
        }

        private void levelVerticalWall31_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 7);
        }

        private void levelVerticalWall32_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 0);
        }

        private void levelVerticalWall33_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 1);
        }

        private void levelVerticalWall34_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 2);
        }

        private void levelVerticalWall35_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 3);
        }

        private void levelVerticalWall36_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 4);
        }

        private void levelVerticalWall37_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 5);
        }

        private void levelVerticalWall38_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 6);
        }

        private void levelVerticalWall39_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 7);
        }

        private void levelVerticalWall40_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 0);
        }

        private void levelVerticalWall41_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 1);
        }

        private void levelVerticalWall42_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 2);
        }

        private void levelVerticalWall43_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 3);
        }

        private void levelVerticalWall44_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 4);
        }

        private void levelVerticalWall45_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 5);
        }

        private void levelVerticalWall46_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 6);
        }

        private void levelVerticalWall47_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 7);
        }

        private void levelVerticalWall48_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 0);
        }

        private void levelVerticalWall49_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 1);
        }

        private void levelVerticalWall50_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 2);
        }

        private void levelVerticalWall51_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 3);
        }

        private void levelVerticalWall52_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 4);
        }

        private void levelVerticalWall53_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 5);
        }

        private void levelVerticalWall54_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 6);
        }

        private void levelVerticalWall55_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 7);
        }

        private void levelHorizontalWall0_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(0, 0);
        }

        private void levelHorizontalWall1_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(0, 1);
        }

        private void levelHorizontalWall2_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(0, 2);
        }

        private void levelHorizontalWall3_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(0, 3);
        }

        private void levelHorizontalWall4_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(0, 4);
        }

        private void levelHorizontalWall5_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(0, 5);
        }

        private void levelHorizontalWall6_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(0, 6);
        }

        private void levelHorizontalWall7_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(1, 0);
        }

        private void levelHorizontalWall8_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(1, 1);
        }

        private void levelHorizontalWall9_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(1, 2);
        }

        private void levelHorizontalWall10_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(1, 3);
        }

        private void levelHorizontalWall11_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(1, 4);
        }

        private void levelHorizontalWall12_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(1, 5);
        }

        private void levelHorizontalWall13_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(1, 6);
        }

        private void levelHorizontalWall14_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(2, 0);
        }

        private void levelHorizontalWall15_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(2, 1);
        }

        private void levelHorizontalWall16_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(2, 2);
        }

        private void levelHorizontalWall17_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(2, 3);
        }

        private void levelHorizontalWall18_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(2, 4);
        }

        private void levelHorizontalWall19_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(2, 5);
        }

        private void levelHorizontalWall20_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(2, 6);
        }

        private void levelHorizontalWall21_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(3, 0);
        }

        private void levelHorizontalWall22_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(3, 1);
        }

        private void levelHorizontalWall23_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(3, 2);
        }

        private void levelHorizontalWall24_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(3, 3);
        }

        private void levelHorizontalWall25_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(3, 4);
        }

        private void levelHorizontalWall26_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(3, 5);
        }

        private void levelHorizontalWall27_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(3, 6);
        }

        private void levelHorizontalWall28_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(4, 0);
        }

        private void levelHorizontalWall29_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(4, 1);
        }

        private void levelHorizontalWall30_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(4, 2);
        }

        private void levelHorizontalWall31_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(4, 3);
        }

        private void levelHorizontalWall32_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(4, 4);
        }

        private void levelHorizontalWall33_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(4, 5);
        }

        private void levelHorizontalWall34_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(4, 6);
        }

        private void levelHorizontalWall35_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(5, 0);
        }

        private void levelHorizontalWall36_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(5, 1);
        }

        private void levelHorizontalWall37_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(5, 2);
        }

        private void levelHorizontalWall38_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(5, 3);
        }

        private void levelHorizontalWall39_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(5, 4);
        }

        private void levelHorizontalWall40_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(5, 5);
        }

        private void levelHorizontalWall41_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(5, 6);
        }

        private void levelHorizontalWall42_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(6, 0);
        }

        private void levelHorizontalWall43_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(6, 1);
        }

        private void levelHorizontalWall44_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(6, 2);
        }

        private void levelHorizontalWall45_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(6, 3);
        }

        private void levelHorizontalWall46_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(6, 4);
        }

        private void levelHorizontalWall47_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(6, 5);
        }

        private void levelHorizontalWall48_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(6, 6);
        }

        private void levelHorizontalWall49_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(7, 0);
        }

        private void levelHorizontalWall50_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(7, 1);
        }

        private void levelHorizontalWall51_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(7, 2);
        }

        private void levelHorizontalWall52_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(7, 3);
        }

        private void levelHorizontalWall53_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(7, 4);
        }

        private void levelHorizontalWall54_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(7, 5);
        }

        private void levelHorizontalWall55_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(7, 6);
        }

        private void potionButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNotePotion();
        }

        private void whiteSwordButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteWhiteSword();
        }

        private void magicalSwordButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteMagicalSword();
        }

        private void w1Button_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteWarpZone1();
        }

        private void w2Button_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteWarpZone2();
        }

        private void w3Button_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteWarpZone3();
        }

        private void w4Button_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteWarpZone4();
        }

        private void hintButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteHint();
        }

        private void moneyButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteMoney();
        }

        private void allRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            m_overworldTracker.SetShopFilterAll();
        }

        private void candleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            m_overworldTracker.SetShopFilterCandle();
        }

        private void arrowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            m_overworldTracker.SetShopFilterArrow();
        }

        private void foodRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            m_overworldTracker.SetShopFilterFood();
        }

        private void ringRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            m_overworldTracker.SetShopFilterRing();
        }

        private void keyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            m_overworldTracker.SetShopFilterKey();
        }

        private void bombRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            m_overworldTracker.SetShopFilterBomb();
        }

        private void bibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_overworldTracker.SetHasBible(bibleCheckBox.Checked);
        }

        private void bibleButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteShopBible();
        }

        private void candleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_overworldTracker.SetHasCandle(candleCheckBox.Checked);
        }

        private void blueCandleButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteShopCandle();
        }

        private void arrowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_overworldTracker.SetHasArrow(arrowCheckBox.Checked);
        }

        private void arrowButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteShopArrow();
        }

        private void foodCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_overworldTracker.SetHasFood(foodCheckBox.Checked);
        }

        private void foodButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteShopFood();
        }

        private void ringCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_overworldTracker.SetHasRing(ringCheckBox.Checked);
        }

        private void blueRingButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteShopRing();
        }

        private void keyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_overworldTracker.SetHasKey(keyCheckBox.Checked);
        }

        private void keyButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteShopKey();
        }

        private void bombButton_Click(object sender, EventArgs e)
        {
            m_overworldTracker.SetNoteShopBomb();
        }

        private void levelRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(0);
        }

        private void levelRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(1);
        }

        private void levelRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(2);
        }

        private void levelRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(3);
        }

        private void levelRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(4);
        }

        private void levelRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(5);
        }

        private void levelRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(6);
        }

        private void levelRadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(7);
        }

        private void levelRadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(8);
        }

        private void levelRadioButtonUnknown_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(9);
        }

        private void firstQuestButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "1st Quest", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                m_overworldTracker.SetFirstQuest();
            }
        }

        private void secondQuestButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "2nd Quest", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                m_overworldTracker.SetSecondQuest();
            }
        }

        private void mixedQuestButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Mixed Quest", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                m_overworldTracker.SetMixedQuest();
            }
        }

        private void filterFirstButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Mixed to 1st", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                m_overworldTracker.FilterToFirst();
            }
        }

        private void filterSecondButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Mixed to 2nd", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                m_overworldTracker.FilterToSecond();
                smallNumericUpDown.Value += 2;
                largeNumericUpDown.Value -= 2;
            }
        }

        OverworldTracker m_overworldTracker;
        LevelTracker[] m_levelTrackers;

        int m_activeLevelIndex = 9;
    }
}
