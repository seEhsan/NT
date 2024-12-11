// Initialize the map
function initMap() {
    // Get the user's current location
    navigator.geolocation.getCurrentPosition(
        (position) => {
            const studentLat = position.coords.latitude;
            const studentLng = position.coords.longitude;

            // Create the map centered on the student's location
            const map = new google.maps.Map(document.getElementById("map"), {
                center: { lat: studentLat, lng: studentLng },
                zoom: 12,
            });

            // Add a marker for the student's location
            new google.maps.Marker({
                position: { lat: studentLat, lng: studentLng },
                map: map,
                title: "You are here",
                icon: "http://maps.google.com/mapfiles/ms/icons/blue-dot.png",
            });

            // Fetch nearby teachers from the API
            fetch(`https://your-api-url/api/teachers/nearby?studentLat=${studentLat}&studentLng=${studentLng}&radius=5`)
                .then((response) => response.json())
                .then((teachers) => {
                    teachers.forEach((teacher) => {
                        // Add markers for each teacher location
                        new google.maps.Marker({
                            position: { lat: teacher.latitude, lng: teacher.longitude },
                            map: map,
                            title: `${teacher.name} - ${teacher.subject}`,
                        });
                    });
                })
                .catch((error) => console.error("Error fetching nearby teachers:", error));
        },
        (error) => console.error("Error retrieving location:", error),
        { enableHighAccuracy: true }
    );
}
