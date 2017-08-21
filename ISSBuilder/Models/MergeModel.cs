using System.Collections.ObjectModel;


namespace ISSBuilder.Models
{
    public class MergeModel : ObservableObject
    {
        private int _numLanes;
        public int NumLanes
        {
            get { return _numLanes; }
            set
            {
                OnPropertyChanged(ref _numLanes, value);
                ConstructLaneList();
            }
        }
        private int _recircID;
        public int RecircID
        {
            get { return _recircID; }
            set { OnPropertyChanged(ref _recircID, value); }
        }
        private ObservableCollection<LaneModel> _lanes;
        public ObservableCollection<LaneModel> Lanes
        {
            get { return _lanes; }
            set { OnPropertyChanged(ref _lanes, value); }
        }

        private string _mergeBeltName;
        public string MergeBeltName
        {
            get { return _mergeBeltName; }
            set { OnPropertyChanged(ref _mergeBeltName, value); }
        }

        public MergeModel()
        {
            Lanes = new ObservableCollection<LaneModel>();
            MergeBeltName = "UXXXXXX";
        }

        private void ConstructLaneList()
        {
            if (Lanes.Count == 0)
            {
                for (var i = 1; i <= NumLanes; i++)
                {
                    Lanes.Add(new LaneModel(i, "", "", ""));
                }
            }

            else if( NumLanes > Lanes.Count)
            {
                for (var i = Lanes.Count; i < NumLanes; i++)
                {
                    Lanes.Add(new LaneModel(i+1, "", "", ""));
                }
            }

            else if (Lanes.Count > NumLanes)
            {
                //var numToRemove = Lanes.Count - NumLanes;
                while(Lanes.Count > NumLanes)
                {
                    Lanes.RemoveAt(Lanes.Count-1);
                }
            }
        }
    }
}
