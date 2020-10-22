using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NVCLed.Controls
{
  public class LedControl : ContentControl
  {
    #region [ Construction ]

    public LedControl()
    {
      Loaded += DrawLed;

    }
    #endregion

    #region [ Method ]

    private void DrawLed(object sender, RoutedEventArgs e)
    {

      // The original build size
      const double DESIGNED_SIZE = 100;

      // Store the original Margin
      Thickness _Margin = new Thickness(Margin.Left, Margin.Top, Margin.Right, Margin.Bottom);
      Margin = new Thickness(0, 0, 0, 0);

      Canvas panel = new Canvas();
      Content = panel;
      panel.Children.Clear();
      double size;
      double left = 0;
      double top = 0;

      // Give it default size 16 if no Height or Width is given.
      if (!double.IsNaN(Height))
      {
        size = Height;
      }
      else if (!double.IsNaN(Width))
      {
        size = Width;
      }
      else
      {
        size = 16;
      }

      double factor = size / DESIGNED_SIZE;

      #region Outside circle
      size = 100 * factor;
      double distance = (DESIGNED_SIZE * factor - size);
      Ellipse ellipse1 = new Ellipse
      {
        Width = size,
        Height = size,
        StrokeThickness = 0.5,
        Stroke = Brushes.Gray
      };

      ellipse1.Margin = new Thickness(left, top, 0, 0);

      LinearGradientBrush lgb1 = new LinearGradientBrush(new GradientStopCollection
      {
        new GradientStop(Color.FromArgb(255, 6, 9, 12), 0d),
        new GradientStop(Color.FromArgb(255, 255, 255, 255), 1d)
      })
      {
        StartPoint = new Point(0.5d, 1d),
        EndPoint = new Point(1d, 0d),
        SpreadMethod = GradientSpreadMethod.Pad
      };

      ellipse1.Fill = lgb1;
      panel.Children.Add(ellipse1);

      #endregion

      #region Inside circle
      size = 90 * factor;
      distance = (DESIGNED_SIZE * factor - size) / 2;
      left = distance;
      top = distance;
      Ellipse ellipse2 = new Ellipse
      {
        Width = size,
        Height = size,
        StrokeThickness = 0.5,
        Stroke = Brushes.Gray
      };

      ellipse2.Margin = new Thickness(left, top, 0, 0);

      LinearGradientBrush lgb2 = new LinearGradientBrush(new GradientStopCollection
      {
        new GradientStop(Color.FromArgb(255, 6, 9, 12), 0d),
        new GradientStop(Color.FromArgb(255, 255, 255, 255), 1d)
      })
      {
        StartPoint = new Point(1d, 0.5d),
        EndPoint = new Point(0d, 1d),
        SpreadMethod = GradientSpreadMethod.Pad
      };

      ellipse2.Fill = lgb2;
      panel.Children.Add(ellipse2);
      #endregion

      #region 'Led' circle
      size = 85 * factor;
      distance = (DESIGNED_SIZE * factor - size) / 2;
      left = Margin.Left + distance;
      top = Margin.Top + distance;
      Ellipse ellipseLed = new Ellipse
      {
        Width = size,
        Height = size,
        StrokeThickness = 0.5,
        Stroke = Brushes.Black
      };

      ellipseLed.Margin = new Thickness(left, top, 0, 0);

      RadialGradientBrush rgb = new RadialGradientBrush(new GradientStopCollection
      {
        new GradientStop(Color.FromArgb(192, 255, 255, 255), 0),
        new GradientStop(Color.FromArgb(64, 169, 169, 169), 0.5)
      });
      new TransformGroup().Children.Add(new ScaleTransform
      {
        CenterX = 0.6,
        CenterY = 0.35,
        ScaleX = 1,
        ScaleY = 1
      });
      new TransformGroup().Children.Add(new SkewTransform
      {
        AngleX = 0,
        AngleY = 0,
        CenterX = 0.6,
        CenterY = 0.35
      });
      new TransformGroup().Children.Add(new RotateTransform
      {
        Angle = -4.447,
        CenterX = 0.6,
        CenterY = 0.35
      });
      new TransformGroup().Children.Add(new TranslateTransform
      {
        X = 0,
        Y = 0
      });
      rgb.Transform = new TransformGroup();
      rgb.Center = new Point(0.6, 0.35);
      rgb.GradientOrigin = new Point(0.6, 0.25);
      rgb.RadiusX = 0.67;
      rgb.RadiusY = 0.67;

      ellipseLed.Fill = rgb;
      panel.Children.Add(ellipseLed);

      #endregion

      //Restore the margin
      Margin = _Margin;
    }

    #endregion
  }
}
