using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace MapApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMap.Bearing = 0;
            gMap.CanDragMap = true;
            gMap.DragButton = MouseButtons.Left;
            gMap.GrayScaleMode = true;
            gMap.MarkersEnabled = true;
            gMap.MaxZoom = 18;
            gMap.MinZoom = 2;
            gMap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            gMap.NegativeMode = false;
            gMap.PolygonsEnabled = true;
            gMap.RoutesEnabled = true;
            gMap.ShowTileGridLines = false;
            gMap.Zoom = 10;
            //gMap.Dock = DockStyle.Fill;
            gMap.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMap.Position = new PointLatLng(55.75393, 37.620795);

            GMapOverlay markersOverlay = new GMapOverlay("markers");

            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(55.75393, 37.731895), GMarkerGoogleType.red);
            marker.ToolTip = new GMapRoundedToolTip(marker);
            marker.ToolTipText = "AbrSoft Technologies";
            markersOverlay.Markers.Add(marker);

            GMarkerGoogle marker2 = new GMarkerGoogle(new PointLatLng(55.77393, 37.731895), GMarkerGoogleType.blue);
            marker2.ToolTip = new GMapRoundedToolTip(marker2);
            marker2.ToolTipText = "AbramSoft Technologies";
            markersOverlay.Markers.Add(marker2);

            gMap.Overlays.Add(markersOverlay);

            trackBar1.Maximum = 18;
            trackBar1.Minimum = 2;
            trackBar1.Value = (int)gMap.Zoom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            gMap.Zoom = trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Конец");
            Close();
        }

        private void gMap_OnMapTypeChanged(GMapProvider type)
        {
            trackBar1.Value = (int)gMap.Zoom;
        }
    }
}
