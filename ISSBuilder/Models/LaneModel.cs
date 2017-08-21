namespace ISSBuilder.Models
{
    public class LaneModel : ObservableObject
    {
        private int _laneNumber;
        public int LaneNumber
        {
            get { return _laneNumber; }
            set { OnPropertyChanged(ref _laneNumber, value); }
        }
        private string _meterBeltName;
        public string MeterBeltName
        {
            get { return _meterBeltName; }
            set { OnPropertyChanged(ref _meterBeltName, value); }
        }

        private string _slugBeltName;
        public string SlugBeltName
        {
            get { return _slugBeltName; }
            set { OnPropertyChanged(ref _slugBeltName, value); }
        }

        private string _wedgeName;
        public string WedgeName
        {
            get { return _wedgeName; }
            set { OnPropertyChanged(ref _wedgeName, value); }
        }

        public LaneModel(int laneNumber, string meterBeltName, string slugBeltName, string wedgeName)
        {
            LaneNumber = laneNumber;
            MeterBeltName = meterBeltName;
            SlugBeltName = slugBeltName;
            WedgeName = wedgeName;
        }
    }
}
