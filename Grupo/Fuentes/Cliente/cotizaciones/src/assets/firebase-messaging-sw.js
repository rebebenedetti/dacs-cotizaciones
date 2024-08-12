import { initializeApp } from "https://www.gstatic.com/firebasejs/10.12.5/firebase-app.js";
import { getMessaging } from "https://www.gstatic.com/firebasejs/10.12.5/firebase-messaging-sw.js";

const firebaseApp = initializeApp({
        apiKey: "AIzaSyDnz-dVqMKoK4ugngPUIX-p92VavYdwB1U",
        authDomain: "cotizaciones-dacs.firebaseapp.com",
        projectId: "cotizaciones-dacs",
        storageBucket: "cotizaciones-dacs.appspot.com",
        messagingSenderId: "110595511262",
        appId: "1:110595511262:web:fda5e84bbdbbc5c30bc34f",
});

const messaging = getMessaging(firebaseApp);

messaging.onBackgroundMessage(function(payload) {
        console.log('[firebase-messaging-sw.js] Received background message ', payload);
        const notificationTitle = payload.notification.title;
        const notificationOptions = {
          body: payload.notification.body,
          icon: '/firebase-logo.png'
        };
      
        self.registration.showNotification(notificationTitle, notificationOptions);
});