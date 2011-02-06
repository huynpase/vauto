/*
*	Copyright © 2011, The Vibzworld Team
*	All rights reserved.
*	http://code.google.com/p/vauto/
*	
*	Redistribution and use in source and binary forms, with or without
*	modification, are permitted provided that the following conditions
*	are met:
*	
*	- Redistributions of source code must retain the above copyright
*	notice, this list of conditions and the following disclaimer.
*	
*	- Neither the name of the Vibzworld Team, nor the names of its
*	contributors may be used to endorse or promote products
*	derived from this software without specific prior written
*	permission.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vibz.IO.Window
{
    public partial class TextAlertForm : Form
    {
        const int TimerIteration = 50;
        const int StableIteration = 40;
        ExitMode _eMode = ExitMode.AutoClose;
        DisplayMode _dMode = DisplayMode.Static;
        Direction _direction = Direction.RightToLeft;
        Position _position = Position.BottomRight;
        double _opacity = 0;
        int _positionOffset = 0;
        int _totalDuration = 0;
        int _stayDuration = 0;
        int _staleDuration = 0;
        bool _setPosition = false;
        Timer _t = new Timer();
        Rectangle rect = new Rectangle(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);

        public TextAlertForm(string message, DisplayMode displayMode, ExitMode exitMode, Direction direction, Position position, int duration)
        {
            InitializeComponent();
            lblMessage.Text = message;
            _dMode = displayMode;
            _eMode = exitMode;
            _position = position;
            _direction = direction;
            _totalDuration = duration;

            foreach (Screen screen in Screen.AllScreens)
                rect = Rectangle.Union(rect, screen.Bounds);

            this.StartPosition = FormStartPosition.Manual;
            switch (_position)
            {
                case Position.Center:
                    this.Location = new Point((rect.Width - this.Width) / 2, (rect.Height - this.Height) / 2);
                    break;
                case Position.BottomRight:
                    this.Location = new Point(rect.Width - this.Width, rect.Height - this.Height);
                    break;
            }
            switch (_dMode)
            {
                case DisplayMode.CrawlIn:
                case DisplayMode.FadeCrawlIn:
                    _setPosition = true;
                    switch (_direction)
                    {
                        case Direction.RightToLeft:
                            this.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                            break;
                        case Direction.LeftToRight:
                            this.Location = new Point(this.Location.X - this.Width, this.Location.Y);
                            break;
                        case Direction.BottomToTop:
                            this.Location = new Point(this.Location.X, this.Location.Y + this.Height);
                            break;
                        case Direction.TopToBottom:
                            this.Location = new Point(this.Location.X, this.Location.Y - this.Height);
                            break;
                    }
                    break;
                default:
                    break;
            }
            switch (_direction)
            {
                case Direction.RightToLeft:
                case Direction.LeftToRight:
                    _positionOffset = (this.Width / StableIteration);
                    break;
                case Direction.TopToBottom:
                case Direction.BottomToTop:
                    _positionOffset = (this.Height / StableIteration);
                    break;
            }
            SetWindowState();

            _t.Interval = TimerIteration;
            _t.Tick += new EventHandler(_t_Tick);
            _t.Start();
        }

        void _t_Tick(object sender, EventArgs e)
        {
            _stayDuration += TimerIteration;
            _staleDuration += _positionOffset;
            SetWindowState();
            if ((ExitMode.AutoClose == _eMode) && (_stayDuration > _totalDuration))
                AutoClose();
        }

        void SetWindowState()
        {
            switch (_dMode)
            {
                case DisplayMode.FadeIn:
                case DisplayMode.FadeCrawlIn:
                    this._opacity += (TimerIteration / StableIteration);
                    this.Opacity = this._opacity / 100; 
                    break;
                default:
                    break;
            }
            if (_setPosition && (_staleDuration < (_positionOffset * StableIteration)))
            {
                switch (_direction)
                {
                    case Direction.RightToLeft:
                        this.Location = new Point(this.Location.X - _positionOffset, this.Location.Y);
                        break;
                    case Direction.LeftToRight:
                        this.Location = new Point(this.Location.X + _positionOffset, this.Location.Y); ;
                        break;
                    case Direction.BottomToTop:
                        this.Location = new Point(this.Location.X, this.Location.Y - _positionOffset);
                        break;
                    case Direction.TopToBottom:
                        this.Location = new Point(this.Location.X, this.Location.Y + _positionOffset);
                        break;
                }
            }
        }
        void AutoClose()
        {
            if (!this.DesktopBounds.Contains(Cursor.Position))
            {
                _t.Stop();
                this.Close();
            }
        }
        public TextAlertForm()
            : this("No message...", DisplayMode.FadeIn, ExitMode.AutoClose, Direction.RightToLeft, Position.BottomRight, 10000)
        {
        }
    }
}
