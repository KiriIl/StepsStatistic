using LiveChartsCore.ConditionalDraw;
using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using StepsStatistic.Models;
using System.Collections.ObjectModel;
using System.Linq;
using LiveChartsCore;

namespace StepsStatistic.ViewModels
{
    public class ChartViewModel : BaseViewModel
    {
        public ObservableCollection<ISeries> Series { get; }
        public ObservableCollection<Axis> Labels { get; }

        public ChartViewModel()
        {
            Series = new ObservableCollection<ISeries>();
            Labels = new ObservableCollection<Axis>();
        }

        public void UpdateChart(UserModel userModel)
        {
            Series.Clear();
            Labels.Clear();

            if (userModel != null)
            {
                Series.Add(new LineSeries<StatModel>
                {
                    Name = userModel.User,
                    Values = userModel.Stats,
                    Mapping = (stat, point) =>
                    {
                        point.PrimaryValue = stat.Steps;
                        point.SecondaryValue = point.Context.Entity.EntityIndex;
                    },
                    TooltipLabelFormatter = DayWithStepsToolTipFormatter,
                }
                .WithConditionalPaint(new SolidColorPaint(SKColors.Green))
                .When(point => HighPointsPredicate(point, userModel))
                .WithConditionalPaint(new SolidColorPaint(SKColors.Red))
                .When(point => LowPointsPredicate(point, userModel)));


                Labels.Add(new Axis()
                {
                    Labels = userModel.Stats.Select(x => x.Article).ToList(),
                });
            }
        }

        private string DayWithStepsToolTipFormatter(
            ChartPoint<StatModel, BezierPoint<CircleGeometry>, LabelGeometry> point)
        {
            return $"{point.Model.Article} : steps {point.Model.Steps}";
        }

        private bool LowPointsPredicate(
            ChartPoint<StatModel, BezierPoint<CircleGeometry>, LabelGeometry> point,
            UserModel model)
        {
            return point.Model.Steps >= model.BestResult;
        }

        private bool HighPointsPredicate(
            ChartPoint<StatModel, BezierPoint<CircleGeometry>, LabelGeometry> point,
            UserModel model)
        {
            return point.Model.Steps <= model.BestResult;
        }
    }
}