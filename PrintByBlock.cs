using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;
using System;

namespace AutocadInitialization
{
    public class PrintByBlock
    {
        public string PrinterName { get; set; }
        public string PaperSize { get; set; }
        public string PlotStyle { get; set; }
        public string LayerName { get; set; }
        public string BlockName { get; set; }
        public bool CenterPlot { get; set; }
        public int NoOfPages { get; set; }
        public double PlotScale { get; set; }

        private AcadDocument acadDocument;
        public PrintByBlock(AcadDocument acadDoc)
        {
            acadDocument = acadDoc;
            try
            {
                if (acadDocument.ActiveSpace != Autodesk.AutoCAD.Interop.Common.AcActiveSpace.acPaperSpace)
                {
                    acadDocument.ActiveSpace = Autodesk.AutoCAD.Interop.Common.AcActiveSpace.acPaperSpace;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void Print()
        {

            AcadSelectionSet sSet;
            try
            {
                sSet = acadDocument.SelectionSets.Item("Frames");//sSets.Item("Frames");
            }
            catch
            {
                sSet = acadDocument.SelectionSets.Add("Frames");
            }
            if (sSet != null)
            {
                sSet.Clear();
            }
            //Filter Drawing frame block
            short[] FilterType = new short[3];
            object[] FilterData = new object[3];

            //0: Entity type(like "LINE", "CIRCLE", "INSERT" for blocks, etc.)
            //2: Block name(for INSERT entities)
            //8: Layer name
            //62: Color number
            //6: Linetype name
            //Filter by block
            FilterType[0] = 0;
            FilterData[0] = "INSERT";

            //Filter by Layer
            FilterType[1] = 8;
            FilterData[1] = LayerName;

            //Filter by block name
            FilterType[2] = 2;
            FilterData[2] = BlockName;

            sSet.Select(Autodesk.AutoCAD.Interop.Common.AcSelect.acSelectionSetAll, Type.Missing, Type.Missing, FilterType, FilterData);
            //sSet.Highlight(true);
            if (sSet.Count == 0)
            {
                return;
            }
            this.NoOfPages = sSet.Count;
            // Process selected entities
            object[,] Dlist = new object[sSet.Count, 2];
            int Dcount = 0;

            foreach (AcadEntity oEnt in sSet)
            {
                if (oEnt is AcadBlockReference oBlock)
                {
                    if (oBlock.EffectiveName == BlockName && oBlock.HasAttributes)
                    {
                        dynamic attObjects = oBlock.GetAttributes();
                        Dlist[Dcount, 0] = oBlock.ObjectID;
                        Dlist[Dcount, 1] = attObjects[0].TextString;
                        Dcount++;
                    }
                }
            }
            //clean uo
            sSet.Delete();

            //Autoprint
            for (long id = 0; id <= Dlist.GetUpperBound(0); id++)
            {
                //get object by id
                AcadEntity oBlocks = acadDocument.ObjectIdToObject((long)Dlist[id, 0]);
                //print block
                //Call Command_plot_block(oBlocks)
                object minPoint = new double[3];
                object maxPoint = new double[3];
                string Direction;
                //Get Minimum Point and Maximum Point of Drawing Frame
                oBlocks.GetBoundingBox(out minPoint, out maxPoint);

                //cast back to double
                // Cast the objects back to double arrays
                double[] minP = (double[])minPoint;
                double[] maxP = (double[])maxPoint;

                if (Math.Abs(maxP[0] - minP[0]) > Math.Abs(maxP[1] - minP[1]))
                {
                    Direction = "Landscape";
                }
                else
                {
                    Direction = "Portrait";
                }

                //Acadapp.ZoomWindow(minP, maxP);

                if (acadDocument.ActiveSpace == AcActiveSpace.acModelSpace)
                {
                    acadDocument.SendCommand(
                        $"-Plot\r" +
                        $"Yes\r" +
                        $"Model\r" +
                        $"pdffactory pro\r" +
                        $"A3\r" +
                        $"Millimeters\r" +
                        $"{Direction}\r" +
                        $"No\r" +
                        $"Window\r" +
                        $"{minP[0]},{minP[1]}\r" +
                        $"{maxP[0]},{maxP[1]}\r" +
                        $"Fit\r" +
                        $"Center\r" +
                        $"Yes\r" +
                        $"\r" +
                        $"Yes\r" +
                        $"\r" +
                        $"No\r" +
                        $"Y\r" +
                        $"Y\r"
                    );
                }
                else
                {
                    acadDocument.SendCommand(
                        $"-Plot\r" +
                        $"Yes\r" +
                        $"\r" +  // Current plot settings
                        $"pdffactory pro\r" +  // Printer/plotter name
                        $"A3\r" +  // Paper size
                        $"Millimeters\r" +  // Drawing orientation
                        $"{Direction}\r" +  // Plot area (Window)
                        $"No\r" +  // Plot scale
                        $"Window\r" +  // Plot area type
                        $"{minP[0]},{minP[1]}\r" +  // Lower-left corner of the window
                        $"{maxP[0]},{maxP[1]}\r" +  // Upper-right corner of the window
                        $"Fit\r" +  // Fit to paper
                        $"Center\r" +  // Center the plot
                        $"Yes\r" +  // Plot upside down
                        $"monochrome.ctb\r" +  // Plot style table
                        $"\r" +  // Plot with plot styles
                        $"Yes\r" +  // Remove hidden lines
                        $"No\r" +  // Scale lineweights
                        $"No\r" +  // Print object lineweights
                        $"No\r" +  // Plot with plot styles
                        $"No\r" +  // Plot paperspace last
                        $"Yes\r" +  // Plot object lineweights
                        $"Yes\r"  // Save changes to page setup
                    );
                }
            }
        }

    }
}

