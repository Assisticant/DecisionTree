using Assisticant;
using Assisticant.Fields;
using DecisionTree.ViewModels.Headers;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace DecisionTree.Views
{
    public partial class ExpectedValueView : UserControl
    {
        private Storyboard _updatedStoryboard;
        private ComputedSubscription _expectedValueSubscription;

        public ExpectedValueView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _updatedStoryboard = (Storyboard)FindResource("UpdatedStoryboard");

            ForView.Unwrap<PathHeader>(DataContext, header =>
            {
                var expectedValue = new Computed<string>(() => header.ExpectedValue);
                _expectedValueSubscription = expectedValue.Subscribe(str =>
                {
                    BeginStoryboard(_updatedStoryboard);
                });
            });
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _expectedValueSubscription.Unsubscribe();
        }
    }
}
