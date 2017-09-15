using System.Collections.ObjectModel;


namespace ISSBuilder.Models
{
    public class MergeProgramModel : ObservableObject
    {
        private string _fa_iss_c;
        public string FA_ISS_C
        {
            get { return _fa_iss_c; }
            set
            {
                OnPropertyChanged(ref _fa_iss_c, value);
            }
        }
        private string _fa_iss_bd;
        public string FA_ISS_BD
        {
            get { return _fa_iss_bd; }
            set { OnPropertyChanged(ref _fa_iss_bd, value); }
        }
       // private ObservableCollection<LaneModel> _lanes;
       // public ObservableCollection<LaneModel> Lanes
       // {
       //     get { return _lanes; }
       //     set { OnPropertyChanged(ref _lanes, value); }
       // }

        public MergeProgramModel()
        {
            //Lanes = new ObservableCollection<LaneModel>();
        }
    }
}
