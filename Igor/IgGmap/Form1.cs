using System;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Collections.Generic;
using Ig.Core;

namespace IgGmap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gMap_Load(object sender, EventArgs e)
        {
            GmapInitialize();

            GMapOverlay markersOverlay = new GMapOverlay("markers");

            AddMarkersFromCsv(markersOverlay);

            gMap.Overlays.Add(markersOverlay);
        }

        private void GmapInitialize()
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
        }

        private void AddMarkersFromCsv(GMapOverlay markersOverlay)
        {
            List<MarkerInfo> MarkerInfoList = MarkerInfo.GetMarkerInfoFromCsv(
                @"C:\Users\admin\source\repos\Igor\Ig.Core\Import\markers.csv");

            foreach (MarkerInfo markerInfo in MarkerInfoList)
            {
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(markerInfo.Latitude,
                                                                        markerInfo.Longitude),
                                                        GMarkerGoogleType.red);
                marker.ToolTip = new GMapRoundedToolTip(marker);
                marker.ToolTipText = markerInfo.Id + ", " + markerInfo.Name;
                markersOverlay.Markers.Add(marker);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
