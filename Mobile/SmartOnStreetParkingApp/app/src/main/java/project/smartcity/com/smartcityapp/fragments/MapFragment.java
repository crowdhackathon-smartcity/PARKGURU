package project.smartcity.com.smartcityapp.fragments;

import android.Manifest;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Color;
import android.location.Location;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.design.widget.BottomSheetBehavior;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.Fragment;
import android.support.v4.content.ContextCompat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.maps.CameraUpdate;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.BitmapDescriptor;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.maps.model.Polygon;
import com.google.android.gms.maps.model.PolygonOptions;
import com.google.android.gms.maps.model.Polyline;
import com.google.android.gms.maps.model.PolylineOptions;
import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import project.smartcity.com.smartcityapp.R;
import project.smartcity.com.smartcityapp.activities.BookTicketActivity;
import project.smartcity.com.smartcityapp.api.RestInterface;
import project.smartcity.com.smartcityapp.api.RestService;
import project.smartcity.com.smartcityapp.helpers.AddressProvider;
import project.smartcity.com.smartcityapp.models.GeometryEdge;
import project.smartcity.com.smartcityapp.models.GeometryType;
import project.smartcity.com.smartcityapp.models.ParkingSpot;
import project.smartcity.com.smartcityapp.models.SearchRequest;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;


public class MapFragment extends Fragment implements OnMapReadyCallback, GoogleMap.OnCameraIdleListener, GoogleMap.OnMyLocationButtonClickListener,
        GoogleMap.OnMarkerClickListener, GoogleMap.OnMapClickListener, GoogleMap.OnPolylineClickListener, GoogleMap.OnCameraMoveStartedListener, GoogleMap.OnPolygonClickListener {

    private OnMapFragmentListener mListener;
    private HashMap<Marker, ParkingSpot> markerParkingSpotHashMap;
    private HashMap<Polyline, ParkingSpot> polylineParkingSpotHashMap;
    private HashMap<Polygon, ParkingSpot> polygonParkingSpotHashMap;
    ParkingSpot selectedParkingSpot;

    public MapFragment() {
    }

    private static int DistanceInMeters = 5000;
    private static int DurationInMinutes = 60;

    Button search;
    private BottomSheetBehavior bottomSheetBehavior;
    private AddressProvider addressProvider;
    Button parkHere;
    TextView zoneName, zoneAddress;
    BitmapDescriptor icon;
    private static String SelectedParkingSpotKey = "pSKey";

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_map, container, false);
        search = (Button) view.findViewById(R.id.search_here_btn);
        bottomSheetBehavior = BottomSheetBehavior.from(view.findViewById(R.id.bottomSheetLayout));
        bottomSheetBehavior.setState(BottomSheetBehavior.STATE_HIDDEN);

        parkHere = (Button) view.findViewById(R.id.park_here_btn);
        zoneName = (TextView) view.findViewById(R.id.zone_name);
        zoneAddress = (TextView) view.findViewById(R.id.address_zone);

        parkHere.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (selectedParkingSpot != null) {
                    Gson gson = new Gson();
                    String selectedParkingSpotPassData = gson.toJson(selectedParkingSpot);
                    Intent i = new Intent(getActivity(), BookTicketActivity.class);
                    i.putExtra(SelectedParkingSpotKey, selectedParkingSpotPassData);
                    startActivity(i);
                }
            }
        });

        LinearLayout bottomSheet = (LinearLayout) view.findViewById(R.id.bottomSheetLayout);
        bottomSheet.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (bottomSheetBehavior.getState() == BottomSheetBehavior.STATE_COLLAPSED) {
                    bottomSheetBehavior.setState(BottomSheetBehavior.STATE_EXPANDED);
                } else {
                    bottomSheetBehavior.setState(BottomSheetBehavior.STATE_COLLAPSED);

                }
            }
        });


        bottomSheetBehavior.setBottomSheetCallback(new BottomSheetBehavior.BottomSheetCallback() {
            @Override
            public void onStateChanged(@NonNull View bottomSheet, int newState) {
                if (newState == BottomSheetBehavior.STATE_EXPANDED) {

                } else {

                }
            }

            @Override
            public void onSlide(@NonNull View bottomSheet, float slideOffset) {

            }
        });


        search.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //define search criteria
                LatLng requestLocation = mMap.getCameraPosition().target;
                SearchRequest searchRequest = new SearchRequest();
                searchRequest.setLatitude(requestLocation.latitude);
                searchRequest.setLongitude(requestLocation.longitude);
                searchRequest.setSearchDistance(DistanceInMeters);
                searchRequest.setDuration(DurationInMinutes);

                RestInterface restInterface = RestService.getRestApiInterface();
                Call<ArrayList<ParkingSpot>> call = restInterface.searchParkingSpots(searchRequest);
                call.enqueue(new Callback<ArrayList<ParkingSpot>>() {
                    @Override
                    public void onResponse(Call<ArrayList<ParkingSpot>> call, Response<ArrayList<ParkingSpot>> response) {
                        if (response.isSuccessful()) {
                            // clear hashMaps
                            markerParkingSpotHashMap.clear();
                            polylineParkingSpotHashMap.clear();
                            polygonParkingSpotHashMap.clear();
                            //clear google map
                            mMap.clear();
                            //go through data and create visual object on map
                            for (ParkingSpot parkingSpot : response.body()) {
                                createVisualRepresentationFromData(parkingSpot);
                            }
                        } else {
                            Toast.makeText(getActivity(), "Something went wrong", Toast.LENGTH_SHORT).show();
                        }
                    }

                    @Override
                    public void onFailure(Call<ArrayList<ParkingSpot>> call, Throwable t) {
                        Toast.makeText(getActivity(), " Sorry Something went wrong", Toast.LENGTH_SHORT).show();

                    }
                });


            }
        });
        SupportMapFragment mapFragment = (SupportMapFragment) getChildFragmentManager().findFragmentById(R.id.map);
        mapFragment.getMapAsync(this);

        return view;
    }


    String onStreetColor;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //each parking has a marker on map AND a polyline
        //so i ll keep track with a HashMap
        markerParkingSpotHashMap = new HashMap<>();
        polylineParkingSpotHashMap = new HashMap<>();
        polygonParkingSpotHashMap = new HashMap<>();
        addressProvider = new AddressProvider(getActivity());

        onStreetColor = "#" + Integer.toHexString(ContextCompat.getColor(getContext(), R.color.blue_light)).trim();


    }

    // TODO: Rename method, update argument and hook method into UI event
    public void onButtonPressed(Uri uri) {
        if (mListener != null) {

        }
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof OnMapFragmentListener) {
            mListener = (OnMapFragmentListener) context;
        } else {
            throw new RuntimeException(context.toString()
                    + " must implement OnMapFragmentListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }


    private GoogleMap mMap;

    @Override
    public void onMapReady(GoogleMap googleMap) {
        mMap = googleMap;
        mMap.setOnCameraIdleListener(this);
        mMap.setOnMapClickListener(this);
        mMap.setOnMyLocationButtonClickListener(this);
        mMap.setOnCameraMoveStartedListener(this);
        mMap.getUiSettings().setScrollGesturesEnabled(true);
        if (ContextCompat.checkSelfPermission(getActivity(), android.Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED) {
            mMap.setMyLocationEnabled(true);
        } else {
            ActivityCompat.requestPermissions(getActivity(), new String[]{Manifest.permission.ACCESS_FINE_LOCATION}, 101);
        }
        mMap.setOnPolylineClickListener(this);
        mMap.setOnMarkerClickListener(this);
        mMap.setOnPolygonClickListener(this);

        icon = BitmapDescriptorFactory.fromResource(R.drawable.icon_park_street);

        search.setEnabled(true);
    }


    public void fixLocation(Location location) {
        //custom fix location demo
//        Latitude:37.9828735
//        Longitude:23.7356535
        if (mMap != null && location != null) {
            LatLng latLng = new LatLng(location.getLatitude(), location.getLongitude());
            CameraUpdate cameraUpdate = CameraUpdateFactory.newLatLngZoom(latLng, 16);//default zoom
            mMap.animateCamera(cameraUpdate);
        }
    }


    public void createVisualRepresentationFromData(ParkingSpot parkingSpot) {
        if (parkingSpot.getAddress() != null) {
            ArrayList<GeometryEdge> edges = new ArrayList<>(parkingSpot.getGeometryEdges());
            //set marker to the first edge of the spot
            LatLng latLng = new LatLng(edges.get(0).getLatitude(), edges.get(0).getLongitude());
            Marker marker = mMap.addMarker(new MarkerOptions().position(latLng).icon(icon));
            markerParkingSpotHashMap.put(marker, parkingSpot);

            int parkingType = parkingSpot.getGeometryType();

            if (parkingType == GeometryType.Line.getValue()) {
                ArrayList<LatLng> latLngArrayList = new ArrayList<>();
                for (GeometryEdge edge : edges) {
                    LatLng latLngEdge = new LatLng(edge.getLatitude(), edge.getLongitude());
                    latLngArrayList.add(latLngEdge);
                }
                PolylineOptions lineOptions = new PolylineOptions();
                lineOptions.addAll(latLngArrayList);
                lineOptions.width(5);
                lineOptions.color(Color.parseColor(onStreetColor));
                Polyline polyline = mMap.addPolyline(lineOptions);
                polylineParkingSpotHashMap.put(polyline, parkingSpot);

            }

            if (parkingType == GeometryType.Polygon.getValue()) {
                ArrayList<LatLng> latLngArrayList = new ArrayList<>();
                for (GeometryEdge edge : edges) {
                    LatLng latLngEdge = new LatLng(edge.getLatitude(), edge.getLongitude());
                    latLngArrayList.add(latLngEdge);
                }
                PolygonOptions polygonOptions = new PolygonOptions();
                polygonOptions.addAll(latLngArrayList);
                polygonOptions.strokeColor(Color.parseColor(onStreetColor));
                polygonOptions.strokeWidth(2);
                polygonOptions.fillColor(Color.parseColor(onStreetColor));
                Polygon polygon = mMap.addPolygon(polygonOptions);
                polygonParkingSpotHashMap.put(polygon, parkingSpot);
            }

        }
    }

    @Override
    public void onCameraIdle() {

    }

    @Override
    public void onMapClick(LatLng latLng) {
        bottomSheetBehavior.setState(BottomSheetBehavior.STATE_HIDDEN);
    }

    @Override
    public boolean onMarkerClick(Marker marker) {
        //get the marker coordinates
        LatLng latLng = marker.getPosition();
        setCameraAndAddressToPosition(latLng);
        if (markerParkingSpotHashMap != null && !markerParkingSpotHashMap.isEmpty()) {
            ParkingSpot parkingSpot = markerParkingSpotHashMap.get(marker);
            displayParkingDataOnBottomSheet(parkingSpot);

        }
        return true;
    }


    @Override
    public void onPolylineClick(Polyline polyline) {
        List<LatLng> polylineEdges = polyline.getPoints();
        LatLng latLng = polylineEdges.get(0);//just get the first edge position
        setCameraAndAddressToPosition(latLng);
        if (polylineParkingSpotHashMap != null && !polylineParkingSpotHashMap.isEmpty()) {
            ParkingSpot parkingSpot = polylineParkingSpotHashMap.get(polyline);
            displayParkingDataOnBottomSheet(parkingSpot);
        }

    }

    @Override
    public void onPolygonClick(Polygon polygon) {
        List<LatLng> polylineEdges = polygon.getPoints();
        LatLng latLng = polylineEdges.get(0);//just get the first edge position
        setCameraAndAddressToPosition(latLng);
        if (polygonParkingSpotHashMap != null && !polygonParkingSpotHashMap.isEmpty()) {
            ParkingSpot parkingSpot = polygonParkingSpotHashMap.get(polygon);
            displayParkingDataOnBottomSheet(parkingSpot);
        }
    }

    private void displayParkingDataOnBottomSheet(ParkingSpot parkingSpot) {
        selectedParkingSpot = parkingSpot;
        zoneName.setText(parkingSpot.getZoneName());
    }

    private void setCameraAndAddressToPosition(LatLng latLng) {
        //update the camera to center the marker
        CameraUpdate cameraUpdate = CameraUpdateFactory.newLatLngZoom(latLng, 20);
        mMap.animateCamera(cameraUpdate, 700, null);
        //expand bottom sheet to reveal
        bottomSheetBehavior.setState(BottomSheetBehavior.STATE_EXPANDED);
        //start an async task to get address
        AsyncFindAddress asyncFindAddress = new AsyncFindAddress();
        asyncFindAddress.execute(latLng);
    }

    @Override
    public void onCameraMoveStarted(int i) {
        //should hide the panel if is expanded
        bottomSheetBehavior.setState(BottomSheetBehavior.STATE_HIDDEN);
    }

    @Override
    public boolean onMyLocationButtonClick() {
        return false;
    }


    public interface OnMapFragmentListener {

    }

    private class AsyncFindAddress extends AsyncTask<LatLng, String, String> {

        private LatLng latLng;


        @Override
        protected void onPreExecute() {
            super.onPreExecute();

        }

        @Override
        protected String doInBackground(LatLng... params) {
            this.latLng = params[0];
            return addressProvider.getAddress(latLng);
        }

        @Override
        protected void onProgressUpdate(String... values) {
            super.onProgressUpdate(values);
        }

        @Override
        protected void onPostExecute(String addressStr) {
            super.onPostExecute(addressStr);
            if (addressStr != null) {
                zoneAddress.setText(addressStr);
            }
        }

    }
}
