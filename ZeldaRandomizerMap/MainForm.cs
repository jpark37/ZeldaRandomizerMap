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

            m_levelTrackers[0, 0].ToggleHorizontal(7, 5, true);
            m_levelTrackers[0, 0].ToggleHorizontal(7, 6, true);
            m_levelTrackers[0, 0].SelectRoom(7, 6);
            m_levelTrackers[0, 0].ToggleVertical(6, 6, false);
            m_levelTrackers[0, 0].SelectRoom(6, 6);

            m_levelTrackers[1, 8].SelectRoom(7, 6);
            m_levelTrackers[1, 8].ToggleVertical(6, 6, false);
            m_levelTrackers[1, 8].SelectRoom(6, 6);

            m_levelTrackers[2, 8].SelectRoom(7, 4);
            m_levelTrackers[2, 8].ToggleVertical(6, 4, false);
            m_levelTrackers[2, 8].SelectRoom(6, 4);

            RefreshLevelsTab(0, 0);
        }

        private LevelTracker[,] InitializeLevelTrackers()
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

            PictureBox[,] roomPictureBoxes11 = new PictureBox[,]
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

            PictureBox[,] roomPictureBoxes12 = new PictureBox[,]
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

            PictureBox[,] roomPictureBoxes13 = new PictureBox[,]
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

            PictureBox[,] roomPictureBoxes14 = new PictureBox[,]
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

            PictureBox[,] roomPictureBoxes15 = new PictureBox[,]
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

            PictureBox[,] roomPictureBoxes16 = new PictureBox[,]
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

            PictureBox[,] roomPictureBoxes17 = new PictureBox[,]
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

            PictureBox[,] roomPictureBoxes18 = new PictureBox[,]
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

            PictureBox[,] roomPictureBoxes19 = new PictureBox[,]
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

            PictureBox[,] roomPictureBoxes21 = new PictureBox[,]
            {
                { null, null, null, levelRoom3,  levelRoom4,  null, null, null },
                { null, null, null, levelRoom11, levelRoom12, null, null, null },
                { null, null, null, levelRoom19, null,        null, null, null },
                { null, null, null, levelRoom27, levelRoom28, null, null, null },
                { null, null, null, levelRoom35, levelRoom36, null, null, null },
                { null, null, null, levelRoom43, null,        null, null, null },
                { null, null, null, levelRoom51, levelRoom52, null, null, null },
                { null, null, null, levelRoom59, levelRoom60, null, null, null },
            };

            PictureBox[,] roomPictureBoxes22 = new PictureBox[,]
            {
                { null, null, null,        levelRoom3,  null,        null, null, null },
                { null, null, levelRoom10, levelRoom11, levelRoom12, null, null, null },
                { null, null, levelRoom18, levelRoom19, levelRoom20, null, null, null },
                { null, null, levelRoom26, levelRoom27, levelRoom28, null, null, null },
                { null, null, levelRoom34, levelRoom35, levelRoom36, null, null, null },
                { null, null, levelRoom42, levelRoom43, levelRoom44, null, null, null },
                { null, null, levelRoom50, null,        levelRoom52, null, null, null },
                { null, null, levelRoom58, null,        levelRoom60, null, null, null },
            };

            PictureBox[,] roomPictureBoxes23 = new PictureBox[,]
            {
                { null,        null, null, null, null, null,        null,        null },
                { null,        null, null, null, null, levelRoom13, null,        null },
                { levelRoom16, null, null, null, null, levelRoom21, null,        null },
                { levelRoom24, null, null, null, null, levelRoom29, null,        null },
                { null,        null, null, null, null, levelRoom37, null,        null },
                { null,        null, null, null, null, levelRoom45, null,        null },
                { null,        null, null, null, null, levelRoom53, levelRoom54, null },
                { null,        null, null, null, null, levelRoom61, levelRoom62, null },
            };

            PictureBox[,] roomPictureBoxes24 = new PictureBox[,]
            {
                { null, null, levelRoom2,  levelRoom3,  levelRoom4,  null,        null, null },
                { null, null, levelRoom10, levelRoom11, levelRoom12, levelRoom13, null, null },
                { null, null, levelRoom18, levelRoom19, levelRoom20, levelRoom21, null, null },
                { null, null, levelRoom26, levelRoom27, levelRoom28, levelRoom29, null, null },
                { null, null, levelRoom34, levelRoom35, levelRoom36, levelRoom37, null, null },
                { null, null, levelRoom42, levelRoom43, levelRoom44, levelRoom45, null, null },
                { null, null, levelRoom50, levelRoom51, levelRoom52, levelRoom53, null, null },
                { null, null, levelRoom58, levelRoom59, levelRoom60, null,        null, null },
            };

            PictureBox[,] roomPictureBoxes25 = new PictureBox[,]
            {
                { null, null, levelRoom2,  levelRoom3,  levelRoom4,  null, null, null },
                { null, null, levelRoom10, levelRoom11, levelRoom12, null, null, null },
                { null, null, null,        null,        levelRoom20, null, null, null },
                { null, null, null,        levelRoom27, levelRoom28, null, null, null },
                { null, null, levelRoom34, levelRoom35, null,        null, null, null },
                { null, null, levelRoom42, null,        null,        null, null, null },
                { null, null, levelRoom50, levelRoom51, levelRoom52, null, null, null },
                { null, null, levelRoom58, levelRoom59, levelRoom60, null, null, null },
            };

            PictureBox[,] roomPictureBoxes26 = new PictureBox[,]
            {
                { null, null,        null,        null,        levelRoom4,  levelRoom5,  levelRoom6,  null },
                { null, null,        null,        levelRoom11, levelRoom12, null,        levelRoom14, null },
                { null, null,        null,        levelRoom19, levelRoom20, null,        levelRoom22, null },
                { null, null,        null,        levelRoom27, levelRoom28, null,        levelRoom30, null },
                { null, null,        levelRoom34, levelRoom35, levelRoom36, null,        null,        null },
                { null, levelRoom41, levelRoom42, levelRoom43, levelRoom44, null,        null,        null },
                { null, null,        null,        levelRoom51, levelRoom52, null,        null,        null },
                { null, null,        null,        null,        levelRoom60, null,        null,        null },
            };

            PictureBox[,] roomPictureBoxes27 = new PictureBox[,]
            {
                { null,        null,        null,        null,        null,        null,        null,        null },
                { null,        null,        levelRoom10, levelRoom11, levelRoom12, levelRoom13, levelRoom14, null },
                { null,        null,        levelRoom18, null,        null,        null,        levelRoom22, null },
                { null,        null,        levelRoom26, levelRoom27, levelRoom28, null,        levelRoom30, null },
                { null,        null,        levelRoom34, levelRoom35, levelRoom36, null,        levelRoom38, null },
                { null,        null,        levelRoom42, levelRoom43, levelRoom44, null,        levelRoom46, null },
                { null,        null,        null,        null,        null,        null,        levelRoom54, null },
                { levelRoom56, levelRoom57, levelRoom58, levelRoom59, levelRoom60, levelRoom61, levelRoom62, null },
            };

            PictureBox[,] roomPictureBoxes28 = new PictureBox[,]
            {
                { levelRoom0,  levelRoom1,  levelRoom2,  levelRoom3,  levelRoom4,  levelRoom5,  levelRoom6,  levelRoom7 },
                { levelRoom8,  levelRoom9,  null,        null,        null,        null,        null,        levelRoom15 },
                { levelRoom16, levelRoom17, null,        null,        null,        levelRoom21, null,        levelRoom23 },
                { levelRoom24, levelRoom25, null,        null,        null,        levelRoom29, null,        levelRoom31 },
                { levelRoom32, levelRoom33, null,        null,        null,        levelRoom37, null,        levelRoom39 },
                { levelRoom40, levelRoom41, null,        null,        null,        levelRoom45, null,        levelRoom47 },
                { levelRoom48, levelRoom49, levelRoom50, levelRoom51, levelRoom52, levelRoom53, null,        levelRoom55 },
                { null,        null,        null,        null,        null,        null,        null,        levelRoom63 },
            };

            PictureBox[,] roomPictureBoxes29 = new PictureBox[,]
            {
                { levelRoom0,  levelRoom1,  null,        null,        null,        null,        levelRoom6,  levelRoom7 },
                { levelRoom8,  levelRoom9,  levelRoom10, levelRoom11, levelRoom12, levelRoom13, levelRoom14, levelRoom15 },
                { null,        null,        levelRoom18, levelRoom19, levelRoom20, levelRoom21, null,        null },
                { null,        levelRoom25, levelRoom26, levelRoom27, levelRoom28, levelRoom29, levelRoom30, null },
                { levelRoom32, levelRoom33, levelRoom34, levelRoom35, levelRoom36, levelRoom37, levelRoom38, levelRoom39 },
                { levelRoom40, levelRoom41, levelRoom42, levelRoom43, levelRoom44, levelRoom45, levelRoom46, levelRoom47 },
                { null,        levelRoom49, levelRoom50, levelRoom51, levelRoom52, levelRoom53, levelRoom54, null },
                { null,        null,        null,        levelRoom59, levelRoom60, null,        null,        null },
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

            PictureBox[,] verticalPictureBoxes11 = new PictureBox[,]
            {
                { null, null, null,                null,                null,                null,                null, null },
                { null, null, null,                null,                null,                null,                null, null },
                { null, null, null,                levelVerticalWall19, null,                null,                null, null },
                { null, null, null,                levelVerticalWall27, null,                levelVerticalWall29, null, null },
                { null, null, levelVerticalWall34, levelVerticalWall35, levelVerticalWall36, null,                null, null },
                { null, null, null,                levelVerticalWall43, null,                null,                null, null },
                { null, null, null,                levelVerticalWall51, null,                null,                null, null },
            };

            PictureBox[,] verticalPictureBoxes12 = new PictureBox[,]
            {
                { null, null, null, null,                levelVerticalWall4,  null,                null, null },
                { null, null, null, null,                levelVerticalWall12, levelVerticalWall13, null, null },
                { null, null, null, null,                levelVerticalWall20, levelVerticalWall21, null, null },
                { null, null, null, null,                levelVerticalWall28, levelVerticalWall29, null, null },
                { null, null, null, null,                levelVerticalWall36, levelVerticalWall37, null, null },
                { null, null, null, null,                levelVerticalWall44, levelVerticalWall45, null, null },
                { null, null, null, levelVerticalWall51, levelVerticalWall52, null,                null, null },
            };

            PictureBox[,] verticalPictureBoxes13 = new PictureBox[,]
            {
                { null, null,                null,                null,                null,                null,                null, null },
                { null, null,                null,                null,                null,                null,                null, null },
                { null, null,                null,                levelVerticalWall19, null,                null,                null, null },
                { null, null,                null,                levelVerticalWall27, null,                levelVerticalWall29, null, null },
                { null, levelVerticalWall33, levelVerticalWall34, levelVerticalWall35, levelVerticalWall36, levelVerticalWall37, null, null },
                { null, levelVerticalWall41, null,                levelVerticalWall43, null,                null,                null, null },
                { null, null,                null,                levelVerticalWall51, null,                null,                null, null },
            };

            PictureBox[,] verticalPictureBoxes14 = new PictureBox[,]
            {
                { null, null, levelVerticalWall2,  levelVerticalWall3,  levelVerticalWall4,  levelVerticalWall5,  null, null },
                { null, null, levelVerticalWall10, levelVerticalWall11, null,                null,                null, null },
                { null, null, levelVerticalWall18, levelVerticalWall19, null,                null,                null, null },
                { null, null, levelVerticalWall26, null,                null,                null,                null, null },
                { null, null, levelVerticalWall34, null,                null,                null,                null, null },
                { null, null, null,                levelVerticalWall43, null,                null,                null, null },
                { null, null, null,                levelVerticalWall51, null,                null,                null, null },
            };

            PictureBox[,] verticalPictureBoxes15 = new PictureBox[,]
            {
                { null, null, null,                levelVerticalWall3,  levelVerticalWall4,  null,                null, null },
                { null, null, levelVerticalWall10, levelVerticalWall11, levelVerticalWall12, levelVerticalWall13, null, null },
                { null, null, levelVerticalWall18, null,                null,                levelVerticalWall21, null, null },
                { null, null, null,                null,                null,                levelVerticalWall29, null, null },
                { null, null, null,                null,                levelVerticalWall36, levelVerticalWall37, null, null },
                { null, null, null,                levelVerticalWall43, levelVerticalWall44, levelVerticalWall45, null, null },
                { null, null, null,                null,                levelVerticalWall52, levelVerticalWall53, null, null },
            };

            PictureBox[,] verticalPictureBoxes16 = new PictureBox[,]
            {
                { null, null,                levelVerticalWall2,  levelVerticalWall3,  levelVerticalWall4,  levelVerticalWall5,  null,                null },
                { null, levelVerticalWall9,  levelVerticalWall10, null,                null,                levelVerticalWall13, levelVerticalWall14, null },
                { null, levelVerticalWall17, levelVerticalWall18, null,                null,                levelVerticalWall21, null,                null },
                { null, levelVerticalWall25, null,                null,                null,                null,                null,                null },
                { null, levelVerticalWall33, null,                null,                null,                null,                null,                null },
                { null, levelVerticalWall41, null,                null,                null,                null,                null,                null },
                { null, levelVerticalWall49, null,                levelVerticalWall51, null,                null,                null,                null },
            };

            PictureBox[,] verticalPictureBoxes17 = new PictureBox[,]
            {
                { null, levelVerticalWall1,  levelVerticalWall2,  levelVerticalWall3,  levelVerticalWall4,  levelVerticalWall5,  null,           null },
                { null, levelVerticalWall9,  levelVerticalWall10, levelVerticalWall11, levelVerticalWall12, null,                null,           null },
                { null, levelVerticalWall17, levelVerticalWall18, levelVerticalWall19, null,                null,                null,           null },
                { null, levelVerticalWall25, levelVerticalWall26, null,                null,                null,                null,           null },
                { null, levelVerticalWall33, levelVerticalWall34, null,                null,                null,                null,           null },
                { null, levelVerticalWall41, levelVerticalWall42, levelVerticalWall43, levelVerticalWall44, null,                null,           null },
                { null, levelVerticalWall49, levelVerticalWall50, levelVerticalWall51, null,                null,                null,           null },
            };

            PictureBox[,] verticalPictureBoxes18 = new PictureBox[,]
            {
                { null, null,                null,                null,                levelVerticalWall4,  null, null, null },
                { null, null,                null,                levelVerticalWall11, levelVerticalWall12, null, null, null },
                { null, null,                levelVerticalWall18, levelVerticalWall19, levelVerticalWall20, null, null, null },
                { null, levelVerticalWall25, levelVerticalWall26, levelVerticalWall27, levelVerticalWall28, null, null, null },
                { null, null,                levelVerticalWall34, levelVerticalWall35, levelVerticalWall36, null, null, null },
                { null, null,                null,                null,                levelVerticalWall44, null, null, null },
                { null, null,                null,                null,                levelVerticalWall52, null, null, null },
            };

            PictureBox[,] verticalPictureBoxes19 = new PictureBox[,]
            {
                { null,                levelVerticalWall1,  levelVerticalWall2,  levelVerticalWall3,  levelVerticalWall4,  levelVerticalWall5,  levelVerticalWall6,  levelVerticalWall7 },
                { levelVerticalWall8,  levelVerticalWall9,  levelVerticalWall10, levelVerticalWall11, levelVerticalWall12, levelVerticalWall13, levelVerticalWall14, levelVerticalWall15 },
                { levelVerticalWall16, levelVerticalWall17, levelVerticalWall18, levelVerticalWall19, levelVerticalWall20, levelVerticalWall21, levelVerticalWall22, levelVerticalWall23 },
                { levelVerticalWall24, levelVerticalWall25, levelVerticalWall26, levelVerticalWall27, levelVerticalWall28, levelVerticalWall29, levelVerticalWall30, levelVerticalWall31 },
                { levelVerticalWall32, levelVerticalWall33, levelVerticalWall34, levelVerticalWall35, levelVerticalWall36, levelVerticalWall37, levelVerticalWall38, levelVerticalWall39 },
                { null,                levelVerticalWall41, levelVerticalWall42, levelVerticalWall43, levelVerticalWall44, levelVerticalWall45, levelVerticalWall46, null },
                { null,                levelVerticalWall49, null,                levelVerticalWall51, levelVerticalWall52, null,                levelVerticalWall54, null },
            };

            PictureBox[,] verticalPictureBoxes21 = new PictureBox[,]
            {
                { null, null, null, levelVerticalWall3,  levelVerticalWall4,  null, null, null },
                { null, null, null, levelVerticalWall11, null,                null, null, null },
                { null, null, null, levelVerticalWall19, null,                null, null, null },
                { null, null, null, levelVerticalWall27, levelVerticalWall28, null, null, null },
                { null, null, null, levelVerticalWall35, null,                null, null, null },
                { null, null, null, levelVerticalWall43, null,                null, null, null },
                { null, null, null, levelVerticalWall51, levelVerticalWall52, null, null, null },
            };

            PictureBox[,] verticalPictureBoxes22 = new PictureBox[,]
            {
                { null, null, null,                levelVerticalWall3,  null,                null, null, null },
                { null, null, levelVerticalWall10, levelVerticalWall11, levelVerticalWall12, null, null, null },
                { null, null, levelVerticalWall18, levelVerticalWall19, levelVerticalWall20, null, null, null },
                { null, null, levelVerticalWall26, levelVerticalWall27, levelVerticalWall28, null, null, null },
                { null, null, levelVerticalWall34, levelVerticalWall35, levelVerticalWall36, null, null, null },
                { null, null, levelVerticalWall42, null,                levelVerticalWall44, null, null, null },
                { null, null, levelVerticalWall50, null,                levelVerticalWall52, null, null, null },
            };

            PictureBox[,] verticalPictureBoxes23 = new PictureBox[,]
            {
                { null,                null, null, null, null, null,                null,                null },
                { null,                null, null, null, null, levelVerticalWall13, null,                null },
                { levelVerticalWall16, null, null, null, null, levelVerticalWall21, null,                null },
                { null,                null, null, null, null, levelVerticalWall29, null,                null },
                { null,                null, null, null, null, levelVerticalWall37, null,                null },
                { null,                null, null, null, null, levelVerticalWall45, null,                null },
                { null,                null, null, null, null, levelVerticalWall53, levelVerticalWall54, null },
            };

            PictureBox[,] verticalPictureBoxes24 = new PictureBox[,]
            {
                { null, null, levelVerticalWall2,  levelVerticalWall3,  levelVerticalWall4,  null,                null, null },
                { null, null, levelVerticalWall10, levelVerticalWall11, levelVerticalWall12, levelVerticalWall13, null, null },
                { null, null, levelVerticalWall18, levelVerticalWall19, levelVerticalWall20, levelVerticalWall21, null, null },
                { null, null, levelVerticalWall26, levelVerticalWall27, levelVerticalWall28, levelVerticalWall29, null, null },
                { null, null, levelVerticalWall34, levelVerticalWall35, levelVerticalWall36, levelVerticalWall37, null, null },
                { null, null, levelVerticalWall42, levelVerticalWall43, levelVerticalWall44, levelVerticalWall45, null, null },
                { null, null, levelVerticalWall50, levelVerticalWall51, levelVerticalWall52, null,                null, null },
            };

            PictureBox[,] verticalPictureBoxes25 = new PictureBox[,]
            {
                { null, null, levelVerticalWall2,  levelVerticalWall3,  levelVerticalWall4,  null, null, null },
                { null, null, null,                null,                levelVerticalWall12, null, null, null },
                { null, null, null,                null,                levelVerticalWall20, null, null, null },
                { null, null, null,                levelVerticalWall27, null,                null, null, null },
                { null, null, levelVerticalWall34, null,                null,                null, null, null },
                { null, null, levelVerticalWall42, null,                null,                null, null, null },
                { null, null, levelVerticalWall50, levelVerticalWall51, levelVerticalWall52, null, null, null },
            };

            PictureBox[,] verticalPictureBoxes26 = new PictureBox[,]
            {
                { null, null, null,                null,                levelVerticalWall4,  null, levelVerticalWall6,  null },
                { null, null, null,                levelVerticalWall11, levelVerticalWall12, null, levelVerticalWall14, null },
                { null, null, null,                levelVerticalWall19, levelVerticalWall20, null, levelVerticalWall22, null },
                { null, null, null,                levelVerticalWall27, levelVerticalWall28, null, null,                null },
                { null, null, levelVerticalWall34, levelVerticalWall35, levelVerticalWall36, null, null,                null },
                { null, null, null,                levelVerticalWall43, levelVerticalWall44, null, null,                null },
                { null, null, null,                null,                levelVerticalWall52, null, null,                null },
            };

            PictureBox[,] verticalPictureBoxes27 = new PictureBox[,]
            {
                { null, null, null,                null,                null,                null, null,                null },
                { null, null, levelVerticalWall10, null,                null,                null, levelVerticalWall14, null },
                { null, null, levelVerticalWall18, null,                null,                null, levelVerticalWall22, null },
                { null, null, levelVerticalWall26, levelVerticalWall27, levelVerticalWall28, null, levelVerticalWall30, null },
                { null, null, levelVerticalWall34, levelVerticalWall35, levelVerticalWall36, null, levelVerticalWall38, null },
                { null, null, null,                null,                null,                null, levelVerticalWall46, null },
                { null, null, null,                null,                null,                null, levelVerticalWall54, null },
            };

            PictureBox[,] verticalPictureBoxes28 = new PictureBox[,]
            {
                { levelVerticalWall0,  levelVerticalWall1,  null, null, null, null,                null, levelVerticalWall7 },
                { levelVerticalWall8,  levelVerticalWall9,  null, null, null, null,                null, levelVerticalWall15 },
                { levelVerticalWall16, levelVerticalWall17, null, null, null, levelVerticalWall21, null, levelVerticalWall23 },
                { levelVerticalWall24, levelVerticalWall25, null, null, null, levelVerticalWall29, null, levelVerticalWall31 },
                { levelVerticalWall32, levelVerticalWall33, null, null, null, levelVerticalWall37, null, levelVerticalWall39 },
                { levelVerticalWall40, levelVerticalWall41, null, null, null, levelVerticalWall45, null, levelVerticalWall47 },
                { null,                null,                null, null, null, null,                null, levelVerticalWall55 },
            };

            PictureBox[,] verticalPictureBoxes29 = new PictureBox[,]
            {
                { levelVerticalWall0,  levelVerticalWall1,  null,                null,                null,                null,                levelVerticalWall6,  levelVerticalWall7 },
                { null,                null,                levelVerticalWall10, levelVerticalWall11, levelVerticalWall12, levelVerticalWall13, null,                null },
                { null,                null,                levelVerticalWall18, levelVerticalWall19, levelVerticalWall20, levelVerticalWall21, null,                null },
                { null,                levelVerticalWall25, levelVerticalWall26, levelVerticalWall27, levelVerticalWall28, levelVerticalWall29, levelVerticalWall30, null },
                { levelVerticalWall32, levelVerticalWall33, levelVerticalWall34, levelVerticalWall35, levelVerticalWall36, levelVerticalWall37, levelVerticalWall38, levelVerticalWall39 },
                { null,                levelVerticalWall41, levelVerticalWall42, levelVerticalWall43, levelVerticalWall44, levelVerticalWall45, levelVerticalWall46, null },
                { null,                null,                null,                levelVerticalWall51, levelVerticalWall52, null,                null,                null },
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

            PictureBox[,] horizontalPictureBoxes11 = new PictureBox[,]
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

            PictureBox[,] horizontalPictureBoxes12 = new PictureBox[,]
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

            PictureBox[,] horizontalPictureBoxes13 = new PictureBox[,]
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

            PictureBox[,] horizontalPictureBoxes14 = new PictureBox[,]
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

            PictureBox[,] horizontalPictureBoxes15 = new PictureBox[,]
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

            PictureBox[,] horizontalPictureBoxes16 = new PictureBox[,]
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

            PictureBox[,] horizontalPictureBoxes17 = new PictureBox[,]
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

            PictureBox[,] horizontalPictureBoxes18 = new PictureBox[,]
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

            PictureBox[,] horizontalPictureBoxes19 = new PictureBox[,]
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

            PictureBox[,] horizontalPictureBoxes21 = new PictureBox[,]
            {
                { null, null, null, levelHorizontalWall3,  null, null, null },
                { null, null, null, levelHorizontalWall10, null, null, null },
                { null, null, null, null,                  null, null, null },
                { null, null, null, levelHorizontalWall24, null, null, null },
                { null, null, null, levelHorizontalWall31, null, null, null },
                { null, null, null, null,                  null, null, null },
                { null, null, null, levelHorizontalWall45, null, null, null },
                { null, null, null, levelHorizontalWall52, null, null, null },
            };

            PictureBox[,] horizontalPictureBoxes22 = new PictureBox[,]
            {
                { null, null, null,                  null,                  null, null, null },
                { null, null, levelHorizontalWall9,  levelHorizontalWall10, null, null, null },
                { null, null, levelHorizontalWall16, levelHorizontalWall17, null, null, null },
                { null, null, levelHorizontalWall23, levelHorizontalWall24, null, null, null },
                { null, null, levelHorizontalWall30, levelHorizontalWall31, null, null, null },
                { null, null, levelHorizontalWall37, levelHorizontalWall38, null, null, null },
                { null, null, null,                  null,                  null, null, null },
                { null, null, null,                  null,                  null, null, null },
            };

            PictureBox[,] horizontalPictureBoxes23 = new PictureBox[,]
            {
                { null, null, null, null, null, null,                  null },
                { null, null, null, null, null, null,                  null },
                { null, null, null, null, null, null,                  null },
                { null, null, null, null, null, null,                  null },
                { null, null, null, null, null, null,                  null },
                { null, null, null, null, null, null,                  null },
                { null, null, null, null, null, levelHorizontalWall47, null },
                { null, null, null, null, null, levelHorizontalWall54, null },
            };

            PictureBox[,] horizontalPictureBoxes24 = new PictureBox[,]
            {
                { null, null, levelHorizontalWall2,  levelHorizontalWall3,  null,                  null, null },
                { null, null, levelHorizontalWall9,  levelHorizontalWall10, levelHorizontalWall11, null, null },
                { null, null, levelHorizontalWall16, levelHorizontalWall17, levelHorizontalWall18, null, null },
                { null, null, levelHorizontalWall23, levelHorizontalWall24, levelHorizontalWall25, null, null },
                { null, null, levelHorizontalWall30, levelHorizontalWall31, levelHorizontalWall32, null, null },
                { null, null, levelHorizontalWall37, levelHorizontalWall38, levelHorizontalWall39, null, null },
                { null, null, levelHorizontalWall44, levelHorizontalWall45, levelHorizontalWall46, null, null },
                { null, null, levelHorizontalWall51, levelHorizontalWall52, null,                  null, null },
            };

            PictureBox[,] horizontalPictureBoxes25 = new PictureBox[,]
            {
                { null, null, levelHorizontalWall2,  levelHorizontalWall3,  null, null, null },
                { null, null, levelHorizontalWall9,  levelHorizontalWall10, null, null, null },
                { null, null, null,                  null,                  null, null, null },
                { null, null, null,                  levelHorizontalWall24, null, null, null },
                { null, null, levelHorizontalWall30, null,                  null, null, null },
                { null, null, null,                  null,                  null, null, null },
                { null, null, levelHorizontalWall44, levelHorizontalWall45, null, null, null },
                { null, null, levelHorizontalWall51, levelHorizontalWall52, null, null, null },
            };

            PictureBox[,] horizontalPictureBoxes26 = new PictureBox[,]
            {
                { null, null,                  null,                  null,                  levelHorizontalWall4, levelHorizontalWall5, null },
                { null, null,                  null,                  levelHorizontalWall10, null,                 null,                 null },
                { null, null,                  null,                  levelHorizontalWall17, null,                 null,                 null },
                { null, null,                  null,                  levelHorizontalWall24, null,                 null,                 null },
                { null, null,                  levelHorizontalWall30, levelHorizontalWall31, null,                 null,                 null },
                { null, levelHorizontalWall36, levelHorizontalWall37, levelHorizontalWall38, null,                 null,                 null },
                { null, null,                  null,                  levelHorizontalWall45, null,                 null,                 null },
                { null, null,                  null,                  null,                  null,                 null,                 null },
            };

            PictureBox[,] horizontalPictureBoxes27 = new PictureBox[,]
            {
                { null,                  null,                  null,                  null,                  null,                  null,                  null },
                { null,                  null,                  levelHorizontalWall9,  levelHorizontalWall10, levelHorizontalWall11, levelHorizontalWall12, null },
                { null,                  null,                  null,                  null,                  null,                  null,                  null },
                { null,                  null,                  levelHorizontalWall23, levelHorizontalWall24, null,                  null,                  null },
                { null,                  null,                  levelHorizontalWall30, levelHorizontalWall31, null,                  null,                  null },
                { null,                  null,                  levelHorizontalWall37, levelHorizontalWall38, null,                  null,                  null },
                { null,                  null,                  null,                  null,                  null,                  null,                  null },
                { levelHorizontalWall49, levelHorizontalWall50, levelHorizontalWall51, levelHorizontalWall52, levelHorizontalWall53, levelHorizontalWall54, null },
            };

            PictureBox[,] horizontalPictureBoxes28 = new PictureBox[,]
            {
                { levelHorizontalWall0,  levelHorizontalWall1,  levelHorizontalWall2,  levelHorizontalWall3,  levelHorizontalWall4,  levelHorizontalWall5, levelHorizontalWall6 },
                { levelHorizontalWall7,  null,                  null,                  null,                  null,                  null,                 null },
                { levelHorizontalWall14, null,                  null,                  null,                  null,                  null,                 null },
                { levelHorizontalWall21, null,                  null,                  null,                  null,                  null,                 null },
                { levelHorizontalWall28, null,                  null,                  null,                  null,                  null,                 null },
                { levelHorizontalWall35, null,                  null,                  null,                  null,                  null,                 null },
                { levelHorizontalWall42, levelHorizontalWall43, levelHorizontalWall44, levelHorizontalWall45, levelHorizontalWall46, null,                 null },
                { null,                  null,                  null,                  null,                  null,                  null,                 null },
            };

            PictureBox[,] horizontalPictureBoxes29 = new PictureBox[,]
            {
                { levelHorizontalWall0,  null,                  null,                  null,                  null,                  null,                  levelHorizontalWall6 },
                { levelHorizontalWall7,  levelHorizontalWall8,  levelHorizontalWall9,  levelHorizontalWall10, levelHorizontalWall11, levelHorizontalWall12, levelHorizontalWall13 },
                { null,                  null,                  levelHorizontalWall16, levelHorizontalWall17, levelHorizontalWall18, null,                  null },
                { null,                  levelHorizontalWall22, levelHorizontalWall23, levelHorizontalWall24, levelHorizontalWall25, levelHorizontalWall26, null },
                { levelHorizontalWall28, levelHorizontalWall29, levelHorizontalWall30, levelHorizontalWall31, levelHorizontalWall32, levelHorizontalWall33, levelHorizontalWall34 },
                { levelHorizontalWall35, levelHorizontalWall36, levelHorizontalWall37, levelHorizontalWall38, levelHorizontalWall39, levelHorizontalWall40, levelHorizontalWall41 },
                { null,                  levelHorizontalWall43, levelHorizontalWall44, levelHorizontalWall45, levelHorizontalWall46, levelHorizontalWall47, null },
                { null,                  null,                  null,                  levelHorizontalWall52, null,                  null,                  null },
            };

            return new LevelTracker[,]
            {
                {
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxesAll, verticalPictureBoxesAll, verticalPictureBoxesAll, horizontalPictureBoxesAll, horizontalPictureBoxesAll),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxesAll, verticalPictureBoxesAll, verticalPictureBoxesAll, horizontalPictureBoxesAll, horizontalPictureBoxesAll),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxesAll, verticalPictureBoxesAll, verticalPictureBoxesAll, horizontalPictureBoxesAll, horizontalPictureBoxesAll),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxesAll, verticalPictureBoxesAll, verticalPictureBoxesAll, horizontalPictureBoxesAll, horizontalPictureBoxesAll),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxesAll, verticalPictureBoxesAll, verticalPictureBoxesAll, horizontalPictureBoxesAll, horizontalPictureBoxesAll),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxesAll, verticalPictureBoxesAll, verticalPictureBoxesAll, horizontalPictureBoxesAll, horizontalPictureBoxesAll),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxesAll, verticalPictureBoxesAll, verticalPictureBoxesAll, horizontalPictureBoxesAll, horizontalPictureBoxesAll),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxesAll, verticalPictureBoxesAll, verticalPictureBoxesAll, horizontalPictureBoxesAll, horizontalPictureBoxesAll),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxesAll, verticalPictureBoxesAll, verticalPictureBoxesAll, horizontalPictureBoxesAll, horizontalPictureBoxesAll),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxesAll, verticalPictureBoxesAll, verticalPictureBoxesAll, horizontalPictureBoxesAll, horizontalPictureBoxesAll),
                },
                {
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes11, verticalPictureBoxesAll, verticalPictureBoxes11, horizontalPictureBoxesAll, horizontalPictureBoxes11),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes12, verticalPictureBoxesAll, verticalPictureBoxes12, horizontalPictureBoxesAll, horizontalPictureBoxes12),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes13, verticalPictureBoxesAll, verticalPictureBoxes13, horizontalPictureBoxesAll, horizontalPictureBoxes13),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes14, verticalPictureBoxesAll, verticalPictureBoxes14, horizontalPictureBoxesAll, horizontalPictureBoxes14),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes15, verticalPictureBoxesAll, verticalPictureBoxes15, horizontalPictureBoxesAll, horizontalPictureBoxes15),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes16, verticalPictureBoxesAll, verticalPictureBoxes16, horizontalPictureBoxesAll, horizontalPictureBoxes16),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes17, verticalPictureBoxesAll, verticalPictureBoxes17, horizontalPictureBoxesAll, horizontalPictureBoxes17),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes18, verticalPictureBoxesAll, verticalPictureBoxes18, horizontalPictureBoxesAll, horizontalPictureBoxes18),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes19, verticalPictureBoxesAll, verticalPictureBoxes19, horizontalPictureBoxesAll, horizontalPictureBoxes19),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxesAll, verticalPictureBoxesAll, verticalPictureBoxesAll, horizontalPictureBoxesAll, horizontalPictureBoxesAll),
                },
                {
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes21, verticalPictureBoxesAll, verticalPictureBoxes21, horizontalPictureBoxesAll, horizontalPictureBoxes21),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes22, verticalPictureBoxesAll, verticalPictureBoxes22, horizontalPictureBoxesAll, horizontalPictureBoxes22),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes23, verticalPictureBoxesAll, verticalPictureBoxes23, horizontalPictureBoxesAll, horizontalPictureBoxes23),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes24, verticalPictureBoxesAll, verticalPictureBoxes24, horizontalPictureBoxesAll, horizontalPictureBoxes24),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes25, verticalPictureBoxesAll, verticalPictureBoxes25, horizontalPictureBoxesAll, horizontalPictureBoxes25),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes26, verticalPictureBoxesAll, verticalPictureBoxes26, horizontalPictureBoxesAll, horizontalPictureBoxes26),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes27, verticalPictureBoxesAll, verticalPictureBoxes27, horizontalPictureBoxesAll, horizontalPictureBoxes27),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes28, verticalPictureBoxesAll, verticalPictureBoxes28, horizontalPictureBoxesAll, horizontalPictureBoxes28),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxes29, verticalPictureBoxesAll, verticalPictureBoxes29, horizontalPictureBoxesAll, horizontalPictureBoxes29),
                    new LevelTracker(roomPictureBoxesAll, roomPictureBoxesAll, verticalPictureBoxesAll, verticalPictureBoxesAll, horizontalPictureBoxesAll, horizontalPictureBoxesAll),
                }
            };
        }

        private void SelectRoom(int row, int column)
        {
            m_levelTrackers[m_activeQuestIndex, m_activeLevelIndex].SelectRoom(row, column);
        }

        private void ToggleVertical(int row, int column, EventArgs e)
        {
            MouseEventArgs mouseArgs = e as MouseEventArgs;
            bool rightClick = mouseArgs != null && mouseArgs.Button == MouseButtons.Right;
            m_levelTrackers[m_activeQuestIndex, m_activeLevelIndex].ToggleVertical(row, column, rightClick);
        }

        private void ToggleHorizontal(int row, int column, EventArgs e)
        {
            MouseEventArgs mouseArgs = e as MouseEventArgs;
            bool rightClick = mouseArgs != null && mouseArgs.Button == MouseButtons.Right;
            m_levelTrackers[m_activeQuestIndex, m_activeLevelIndex].ToggleHorizontal(row, column, rightClick);
        }

        void RefreshLevelsTab(int questIndex, int levelIndex)
        {
            m_activeQuestIndex = questIndex;
            m_activeLevelIndex = levelIndex;

            for (int row = 0; row < 8; ++row)
            {
                for (int column = 0; column < 8; ++column)
                {
                    m_levelTrackers[questIndex, levelIndex].UpdateRoom(row, column);
                }
            }
            for (int row = 0; row < 7; ++row)
            {
                for (int column = 0; column < 8; ++column)
                {
                    m_levelTrackers[questIndex, levelIndex].UpdateVertical(row, column);
                }
            }
            for (int row = 0; row < 8; ++row)
            {
                for (int column = 0; column < 7; ++column)
                {
                    m_levelTrackers[questIndex, levelIndex].UpdateHorizontal(row, column);
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
            m_levelTrackers[m_activeQuestIndex, m_activeLevelIndex].SetRoomPending();
        }

        private void clearRoomButton_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeQuestIndex, m_activeLevelIndex].SetRoomClear();
        }

        private void makeStairsButton_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeQuestIndex, m_activeLevelIndex].SetRoomStairPair();
        }

        private void stairsButtonX_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeQuestIndex, m_activeLevelIndex].SetRoomStairsUnknown();
        }

        private void solidButton_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeQuestIndex, m_activeLevelIndex].SetRoomSolid();
        }

        private void nearPatraButton_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeQuestIndex, m_activeLevelIndex].SetRoomNearPatra();
        }

        private void nearGanonButton_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeQuestIndex, m_activeLevelIndex].SetRoomNearGanon();
        }

        private void ganonButton_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeQuestIndex, m_activeLevelIndex].SetRoomGanon();
        }

        private void zeldaButton_Click(object sender, EventArgs e)
        {
            m_levelTrackers[m_activeQuestIndex, m_activeLevelIndex].SetRoomZelda();
        }

        private void levelVerticalWall0_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 0, e);
        }

        private void levelVerticalWall1_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 1, e);
        }

        private void levelVerticalWall2_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 2, e);
        }

        private void levelVerticalWall3_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 3, e);
        }

        private void levelVerticalWall4_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 4, e);
        }

        private void levelVerticalWall5_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 5, e);
        }

        private void levelVerticalWall6_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 6, e);
        }

        private void levelVerticalWall7_Click(object sender, EventArgs e)
        {
            ToggleVertical(0, 7, e);
        }

        private void levelVerticalWall8_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 0, e);
        }

        private void levelVerticalWall9_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 1, e);
        }

        private void levelVerticalWall10_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 2, e);
        }

        private void levelVerticalWall11_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 3, e);
        }

        private void levelVerticalWall12_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 4, e);
        }

        private void levelVerticalWall13_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 5, e);
        }

        private void levelVerticalWall14_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 6, e);
        }

        private void levelVerticalWall15_Click(object sender, EventArgs e)
        {
            ToggleVertical(1, 7, e);
        }

        private void levelVerticalWall16_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 0, e);
        }

        private void levelVerticalWall17_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 1, e);
        }

        private void levelVerticalWall18_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 2, e);
        }

        private void levelVerticalWall19_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 3, e);
        }

        private void levelVerticalWall20_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 4, e);
        }

        private void levelVerticalWall21_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 5, e);
        }

        private void levelVerticalWall22_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 6, e);
        }

        private void levelVerticalWall23_Click(object sender, EventArgs e)
        {
            ToggleVertical(2, 7, e);
        }

        private void levelVerticalWall24_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 0, e);
        }

        private void levelVerticalWall25_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 1, e);
        }

        private void levelVerticalWall26_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 2, e);
        }

        private void levelVerticalWall27_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 3, e);
        }

        private void levelVerticalWall28_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 4, e);
        }

        private void levelVerticalWall29_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 5, e);
        }

        private void levelVerticalWall30_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 6, e);
        }

        private void levelVerticalWall31_Click(object sender, EventArgs e)
        {
            ToggleVertical(3, 7, e);
        }

        private void levelVerticalWall32_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 0, e);
        }

        private void levelVerticalWall33_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 1, e);
        }

        private void levelVerticalWall34_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 2, e);
        }

        private void levelVerticalWall35_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 3, e);
        }

        private void levelVerticalWall36_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 4, e);
        }

        private void levelVerticalWall37_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 5, e);
        }

        private void levelVerticalWall38_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 6, e);
        }

        private void levelVerticalWall39_Click(object sender, EventArgs e)
        {
            ToggleVertical(4, 7, e);
        }

        private void levelVerticalWall40_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 0, e);
        }

        private void levelVerticalWall41_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 1, e);
        }

        private void levelVerticalWall42_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 2, e);
        }

        private void levelVerticalWall43_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 3, e);
        }

        private void levelVerticalWall44_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 4, e);
        }

        private void levelVerticalWall45_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 5, e);
        }

        private void levelVerticalWall46_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 6, e);
        }

        private void levelVerticalWall47_Click(object sender, EventArgs e)
        {
            ToggleVertical(5, 7, e);
        }

        private void levelVerticalWall48_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 0, e);
        }

        private void levelVerticalWall49_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 1, e);
        }

        private void levelVerticalWall50_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 2, e);
        }

        private void levelVerticalWall51_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 3, e);
        }

        private void levelVerticalWall52_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 4, e);
        }

        private void levelVerticalWall53_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 5, e);
        }

        private void levelVerticalWall54_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 6, e);
        }

        private void levelVerticalWall55_Click(object sender, EventArgs e)
        {
            ToggleVertical(6, 7, e);
        }

        private void levelHorizontalWall0_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(0, 0, e);
        }

        private void levelHorizontalWall1_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(0, 1, e);
        }

        private void levelHorizontalWall2_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(0, 2, e);
        }

        private void levelHorizontalWall3_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(0, 3, e);
        }

        private void levelHorizontalWall4_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(0, 4, e);
        }

        private void levelHorizontalWall5_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(0, 5, e);
        }

        private void levelHorizontalWall6_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(0, 6, e);
        }

        private void levelHorizontalWall7_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(1, 0, e);
        }

        private void levelHorizontalWall8_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(1, 1, e);
        }

        private void levelHorizontalWall9_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(1, 2, e);
        }

        private void levelHorizontalWall10_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(1, 3, e);
        }

        private void levelHorizontalWall11_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(1, 4, e);
        }

        private void levelHorizontalWall12_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(1, 5, e);
        }

        private void levelHorizontalWall13_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(1, 6, e);
        }

        private void levelHorizontalWall14_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(2, 0, e);
        }

        private void levelHorizontalWall15_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(2, 1, e);
        }

        private void levelHorizontalWall16_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(2, 2, e);
        }

        private void levelHorizontalWall17_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(2, 3, e);
        }

        private void levelHorizontalWall18_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(2, 4, e);
        }

        private void levelHorizontalWall19_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(2, 5, e);
        }

        private void levelHorizontalWall20_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(2, 6, e);
        }

        private void levelHorizontalWall21_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(3, 0, e);
        }

        private void levelHorizontalWall22_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(3, 1, e);
        }

        private void levelHorizontalWall23_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(3, 2, e);
        }

        private void levelHorizontalWall24_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(3, 3, e);
        }

        private void levelHorizontalWall25_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(3, 4, e);
        }

        private void levelHorizontalWall26_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(3, 5, e);
        }

        private void levelHorizontalWall27_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(3, 6, e);
        }

        private void levelHorizontalWall28_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(4, 0, e);
        }

        private void levelHorizontalWall29_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(4, 1, e);
        }

        private void levelHorizontalWall30_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(4, 2, e);
        }

        private void levelHorizontalWall31_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(4, 3, e);
        }

        private void levelHorizontalWall32_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(4, 4, e);
        }

        private void levelHorizontalWall33_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(4, 5, e);
        }

        private void levelHorizontalWall34_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(4, 6, e);
        }

        private void levelHorizontalWall35_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(5, 0, e);
        }

        private void levelHorizontalWall36_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(5, 1, e);
        }

        private void levelHorizontalWall37_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(5, 2, e);
        }

        private void levelHorizontalWall38_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(5, 3, e);
        }

        private void levelHorizontalWall39_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(5, 4, e);
        }

        private void levelHorizontalWall40_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(5, 5, e);
        }

        private void levelHorizontalWall41_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(5, 6, e);
        }

        private void levelHorizontalWall42_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(6, 0, e);
        }

        private void levelHorizontalWall43_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(6, 1, e);
        }

        private void levelHorizontalWall44_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(6, 2, e);
        }

        private void levelHorizontalWall45_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(6, 3, e);
        }

        private void levelHorizontalWall46_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(6, 4, e);
        }

        private void levelHorizontalWall47_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(6, 5, e);
        }

        private void levelHorizontalWall48_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(6, 6, e);
        }

        private void levelHorizontalWall49_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(7, 0, e);
        }

        private void levelHorizontalWall50_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(7, 1, e);
        }

        private void levelHorizontalWall51_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(7, 2, e);
        }

        private void levelHorizontalWall52_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(7, 3, e);
        }

        private void levelHorizontalWall53_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(7, 4, e);
        }

        private void levelHorizontalWall54_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(7, 5, e);
        }

        private void levelHorizontalWall55_Click(object sender, EventArgs e)
        {
            ToggleHorizontal(7, 6, e);
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
            RefreshLevelsTab(1, 0);
        }

        private void levelRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(1, 1);
        }

        private void levelRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(1, 2);
        }

        private void levelRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(1, 3);
        }

        private void levelRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(1, 4);
        }

        private void levelRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(1, 5);
        }

        private void levelRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(1, 6);
        }

        private void levelRadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(1, 7);
        }

        private void levelRadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(1, 8);
        }

        private void levelRadioButton21_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(2, 0);
        }

        private void levelRadioButton22_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(2, 1);
        }

        private void levelRadioButton23_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(2, 2);
        }

        private void levelRadioButton24_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(2, 3);
        }

        private void levelRadioButton25_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(2, 4);
        }

        private void levelRadioButton26_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(2, 5);
        }

        private void levelRadioButton27_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(2, 6);
        }

        private void levelRadioButton28_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(2, 7);
        }

        private void levelRadioButton29_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(2, 8);
        }

        private void levelRadioButtonUnknown_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLevelsTab(0, 0);
        }

        private void firstQuestButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "1st Quest", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                m_overworldTracker.SetFirstQuest();
                smallCheckBox1.Visible = false;
                smallCheckBox2.Visible = false;
                largeCheckBox1.Visible = true;
                largeCheckBox2.Visible = true;
            }
        }

        private void secondQuestButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "2nd Quest", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                m_overworldTracker.SetSecondQuest();
                smallCheckBox1.Visible = true;
                smallCheckBox2.Visible = true;
                largeCheckBox1.Visible = false;
                largeCheckBox2.Visible = false;
            }
        }

        private void mixedQuestButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Mixed Quest", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                m_overworldTracker.SetMixedQuest();
                smallCheckBox1.Visible = false;
                smallCheckBox2.Visible = false;
                largeCheckBox1.Visible = true;
                largeCheckBox2.Visible = true;
            }
        }

        private void filterFirstButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Mixed to 1st", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                m_overworldTracker.FilterToFirst();
                smallCheckBox1.Visible = false;
                smallCheckBox2.Visible = false;
                largeCheckBox1.Visible = true;
                largeCheckBox2.Visible = true;
            }
        }

        private void filterSecondButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Mixed to 2nd", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                m_overworldTracker.FilterToSecond();
                smallCheckBox1.Visible = true;
                smallCheckBox2.Visible = true;
                largeCheckBox1.Visible = false;
                largeCheckBox2.Visible = false;
            }
        }

        private void firstQuestDungeonButton_Click(object sender, EventArgs e)
        {
            firstQuestItemCheckBox.Visible = true;
            secondQuestItemCheckBox.Visible = false;
        }

        private void secondQuestDungeonButton_Click(object sender, EventArgs e)
        {
            firstQuestItemCheckBox.Visible = false;
            secondQuestItemCheckBox.Visible = true;
        }

        OverworldTracker m_overworldTracker;
        LevelTracker[,] m_levelTrackers;

        int m_activeQuestIndex = 0;
        int m_activeLevelIndex = 0;
    }
}
