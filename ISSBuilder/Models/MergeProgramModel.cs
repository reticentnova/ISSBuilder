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

        //Temp to test choosing file to import. Will choose based on radio boxes or check boxes in future.
        private string _aoitoimport;
        public string AOITOIMPORT
        {
            get
            { return _aoitoimport; }
            set
            { OnPropertyChanged(ref _aoitoimport, value); }
        }

        //TODO - Need to hold all FA_ISS_* objects in this class.
        private ObservableCollection<FA_ISS_LN> _lanes;
        public ObservableCollection<FA_ISS_LN> Lanes
        {
            get { return _lanes; }
            set { OnPropertyChanged(ref _lanes, value); }
        }

        public MergeProgramModel()
        {
            //Lanes = new ObservableCollection<LaneModel>();
        }
    }
}
