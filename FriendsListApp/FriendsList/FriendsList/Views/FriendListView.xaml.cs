using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsList.BE;
using FriendsList.Repository;
using FriendsList.Views;
using Xamarin.Forms;

namespace FriendsList
{
    public partial class FriendListView : ContentPage
    {
        private FriendRepository _repo = new FriendRepository();
        public FriendListView()
        {
            InitializeComponent();
            SetupPage();
        }

        private void SetupPage()
        {
            Padding = new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 0);

            StackLayout mainLayout = new StackLayout();
            ListViewCustom lvs = new ListViewCustom(ListViewCachingStrategy.RecycleElement);
            lvs.RowHeight = 120;
            lvs.ItemsSource = _repo.ReadAll();

            TopLayout.Children.Add(Title);
            TopLayout.Children.Add(AddBtn);

            mainLayout.Children.Add(TopLayout);
            mainLayout.Children.Add(lvs);

            Content = mainLayout;

        }

        private async void AddFriendBtn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FriendDetailsView(-1));
        }

        public class ListViewCustom : ListView
        {
            private FriendRepository _repo = new FriendRepository();
            public ListViewCustom(ListViewCachingStrategy strategy) : base(strategy)
            {
                ItemTemplate = new DataTemplate(typeof(CustomCell));

            }

            protected override void SetupContent(Cell content, int index)
            {
                base.SetupContent(content, index);
                CustomCell currentViewCell = content as CustomCell;

                if (currentViewCell != null)
                {
                    currentViewCell.View.BackgroundColor = index % 2 == 0
                        ? Color.Aqua
                        : Color.White;
                    currentViewCell.SetupFriend(_repo.ReadAll()[index]);
                    currentViewCell.Tapped += (sender, args) => CurrentViewCellOnTapped(_repo.ReadAll()[index].Id);
                }
                
            }

            private async void CurrentViewCellOnTapped(int id)
            {
                await Navigation.PushAsync(new FriendDetailsView(id));
            }
        }

        public class CustomCell : ViewCell
        {

            private StackLayout imageLayout;
            public CustomCell()
            {

                Grid mainLayout = new Grid();
                

                StackLayout infoLayout = new StackLayout();
                infoLayout.BackgroundColor = Color.Gray;
                infoLayout.Orientation = StackOrientation.Vertical;

                StackLayout buttonLayout = new StackLayout();

                imageLayout = new StackLayout();
                imageLayout.Orientation = StackOrientation.Vertical;

                Label nameLbl = new Label()
                {
                    FontAttributes = FontAttributes.Bold,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                };
                Label phoneLbl = new Label()
                {
                    FontAttributes = FontAttributes.Italic,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                };

                nameLbl.SetBinding(Label.TextProperty, "Name");

                phoneLbl.SetBinding(Label.TextProperty, "PhoneNr");

                infoLayout.Children.Add(nameLbl);
                infoLayout.Children.Add(phoneLbl);

                mainLayout.Children.Add(infoLayout,0,0);
                mainLayout.Children.Add(buttonLayout, 1,0);
                mainLayout.Children.Add(imageLayout, 2,0);

                View = mainLayout;


            }
            public void SetupFriend(Friend f)
            {
                    Image friendImage = new Image();
                    friendImage.HeightRequest = 120;
                    friendImage.Source = "x" + f.Id + ".png";
                    imageLayout.Children.Add(friendImage);
            }
        }


    }
}
