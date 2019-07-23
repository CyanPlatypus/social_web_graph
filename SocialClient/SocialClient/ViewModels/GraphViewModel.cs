using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Dtos;
using QuickGraph;
using SocialClient.Annotations;
using SocialClient.Services;

namespace SocialClient.ViewModels
{
    public class GraphViewModel: INotifyPropertyChanged
    {
        private BidirectionalGraph<object, IEdge<object>> _myGraph;
        private string _name;

        public BidirectionalGraph<object, IEdge<object>> MyGraph
        {
            get => _myGraph;
            set
            {
                _myGraph = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public GraphViewModel()
        {
            var _= NewMethod();
        }

        private async Task NewMethod()
        {
            var result = await UserService.GetUsersAsync();
            var g = new BidirectionalGraph<object, IEdge<object>>();
            //UndirectedGraph
            var userDict = result.ToDictionary(k => k.Id, e => e);
            g.AddVertexRange(result);
            result.ForEach(ug =>
            {
                foreach (var friendId in ug.Friends)
                {
                    g.AddEdge(new Edge<object>(userDict[ug.Id], userDict[friendId]));
                }
            });

            //var a = "a";
            //var b = "b";
            //g.AddVertex(a);
            //g.AddVertex(b);
            //g.AddEdge(new Edge<object>(a, b));

            MyGraph = g;

            Name = "Finished";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}