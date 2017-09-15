using ISSBuilder.Models;
using System.Windows.Input;

namespace ISSBuilder.ViewModels
{
    public class MergeViewModel
    {
        public MergeModel Merge { get; set; }
        public MergeProgramModel ProgramModel { get; set; }
        public ICommand ExportCommand { get; }

        public MergeViewModel()
        {
            ///<summary>
            ///Initialize the merge with
            ///5 lanes and recirc lane to 1
            ///so we have data to show.
            ///</summary>
            Merge = new MergeModel()
            {
                NumLanes = 5,
                RecircID = 1
            };

            ProgramModel = new MergeProgramModel();


            //Bound to Export button in UI. 
            ExportCommand = new RelayCommand(Export);
            void Export()
            {
                Logic.ExportLogic(Merge, ProgramModel);
            }
        }
    }
}
