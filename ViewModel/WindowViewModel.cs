using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Fasetto.Word
{
    public class WindowViewModel : BaseViewModel
    {
        private Window window;
        private int outerMerginSize = 10;
        private int windowRadius = 10;

        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMerginSize); } }

        public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder); } }

        public int WindowRadius
        {
            get
            {
                return window.WindowState == WindowState.Maximized ? 0 : windowRadius;
            }
            set
            {
                this.windowRadius = value;
            }
        }

        public int OuterMerginSize
        {
            get
            {
                return window.WindowState == WindowState.Maximized ? 0 : outerMerginSize;
            }
            set
            {
                this.outerMerginSize = value;
            }
        }

        public Thickness OuterMerginSizeThickness { get { return new Thickness(OuterMerginSize); } }

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(windowRadius); } }

        public int TitleHeight { get; set; } = 26;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + OuterMerginSize); } }

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.LoginPage;

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }

        public WindowViewModel(Window win)
        {
            window = win;

            window.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMerginSize));
                OnPropertyChanged(nameof(OuterMerginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            MinimizeCommand = new RelayCommand(() => { window.WindowState = WindowState.Minimized; });
            MaximizeCommand = new RelayCommand(() => { window.WindowState ^= WindowState.Maximized; });
            CloseCommand = new RelayCommand(() => { window.Close(); });
            MenuCommand = new RelayCommand(() => { SystemCommands.ShowSystemMenu(window, GetMousePosition()); });

            var resizerHelper = new WindowResizer(window);
        }

        /// <summary>
        /// 获取当前鼠标坐标
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(window);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + window.Left, position.Y + window.Top);
        }
    }
}
