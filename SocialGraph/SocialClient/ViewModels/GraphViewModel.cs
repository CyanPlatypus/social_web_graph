using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Data.Dtos;
using QuickGraph;
using SocialClient.Annotations;
using SocialClient.Commands;
using SocialClient.Misc;
using SocialClient.Services;

namespace SocialClient.ViewModels
{
    public class GraphViewModel: INotifyPropertyChanged
    {
        public NotifyTaskExecution<List<UserNodeDto>> NotifyTaskExecution { get; protected set; }

        public RelayCommand ShowUserInfo { get; protected set; }

        private readonly UserService _userService;
        private readonly WindowService _windowService;

        private BidirectionalGraph<object, IEdge<object>> _myGraph;
        
        public BidirectionalGraph<object, IEdge<object>> MyGraph
        {
            get => _myGraph;
            set
            {
                _myGraph = value;
                OnPropertyChanged();
            }
        }

        public GraphViewModel(UserService userService, WindowService windowService)
        {
            _userService = userService;
            _windowService = windowService;
            NotifyTaskExecution = new NotifyTaskExecution<List<UserNodeDto>>();
            NotifyTaskExecution.PropertyChanged += NotifyTaskExecution_PropertyChanged;
            ShowUserInfo = new RelayCommand(obj =>
            {
                if (obj is UserNodeDto un)
                    _windowService.ShowUser(un.Id);
            });
            UpdateGraph();
        }

        protected void UpdateGraph()
        {
            NotifyTaskExecution.StartTask(_userService.GetUsersAsync());
        }

        private void NotifyTaskExecution_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(NotifyTaskExecution.Result))
            {
                MyGraph = BuildGraph(NotifyTaskExecution.Result);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private BidirectionalGraph<object, IEdge<object>> BuildGraph(ICollection<UserNodeDto> users)
        {
            var g = new BidirectionalGraph<object, IEdge<object>>();
            //UndirectedGraph
            var userDict = users.ToDictionary(k => k.Id, e => e);
            g.AddVertexRange(users);

            foreach (var ug in users)
            {
                foreach (var friendId in ug.Friends)
                {
                    g.AddEdge(new Edge<object>(userDict[ug.Id], userDict[friendId]));
                }
            }

            return g;
        }
    }
}