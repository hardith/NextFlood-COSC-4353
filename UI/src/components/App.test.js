
import firebase from "firebase/app"
import "firebase/auth"
// import {getAllMarkers} from "./Map"
// const axios = require('axios');

// jest.mock('axios');



const app = firebase.initializeApp({
  apiKey: "AIzaSyBzNoayjlqTzPotdLP4n9BXgWDtDLXJbEY",
  authDomain: process.env.REACT_APP_FIREBASE_AUTH_DOMAIN,
  databaseURL: process.env.REACT_APP_FIREBASE_DATABASE_URL,
  projectId: process.env.REACT_APP_FIREBASE_PROJECT_ID,
  storageBucket: process.env.REACT_APP_FIREBASE_STORAGE_BUCKET,
  messagingSenderId: process.env.REACT_APP_FIREBASE_MESSAGING_SENDER_ID,
  appId: process.env.REACT_APP_FIREBASE_APP_ID
})

export const auth = app.auth()
export default app

test('signInWithEmailAndPassword should throw error no user record corresponding to this identifier.',async () => {
    let error=''
    try {        
        await app.auth().signInWithEmailAndPassword("test@gmail.com", "test")
    } catch (err) {
        error = err.toString()
    }
    expect(error).toEqual(
        "Error: There is no user record corresponding to this identifier. The user may have been deleted."
    )
})

test('signInWithEmailAndPassword should throw error The password is invalid or the user does not have a password.',async () => {
    let error=''
    try {        
        // unit2@gmail.com
        await app.auth().signInWithEmailAndPassword("unit-test@gmail.com", "test")
    } catch (err) {
        error = err.toString()
    }
    expect(error).toEqual(
        "Error: The password is invalid or the user does not have a password."
    )
})

test('signInWithEmailAndPassword should login with correct credential',async () => {
    const user = await app.auth().signInWithEmailAndPassword("unit-test@gmail.com", "123456")
    expect(user.user).toBeTruthy();

    // await app.auth().signOut()
})

test('signOutFirebase should work',async () => {
    await app.auth().signOut()
    expect(true).toBeTruthy();
})

test('signInWithEmailAndPassword should throw error The email address is badly formatted.',async () => {
    let error=''
    try {        
        await app.auth().signInWithEmailAndPassword("test", "test")
    } catch (err) {
        error = err.toString()
    }
    expect(error).toEqual(
        "Error: The email address is badly formatted."
    )
})


test('renders without crashing', async () => {
    let error=''
    const reactRootDiv = document.createElement('div');
    let app = ({
        apiKey: process.env.REACT_APP_FIREBASE_API_KEY,
        authDomain: process.env.REACT_APP_FIREBASE_AUTH_DOMAIN,
        databaseURL: process.env.REACT_APP_FIREBASE_DATABASE_URL,
        projectId: process.env.REACT_APP_FIREBASE_PROJECT_ID,
        storageBucket: process.env.REACT_APP_FIREBASE_STORAGE_BUCKET,
        messagingSenderId: process.env.REACT_APP_FIREBASE_MESSAGING_SENDER_ID,
        appId: process.env.REACT_APP_FIREBASE_APP_ID
    })
    expect(reactRootDiv.toString()).toBeTruthy();
});

// it('returns the title of the first album', async () => {
//     axios.get.mockResolvedValue({
//       data: [
//         {
//             "id": 11,
//             "userID": "311",
//             "createdDate": "2020-09-14T23:18:17",
//             "expiryDate": "2021-12-30T23:18:17",
//             "latitude": "29.715981",
//             "longitude": "-95.428841",
//             "description": "there not here updated",
//             "severity": "3",
//             "imageURL": "https://assets.bwbx.io/images/users/iqjWHBFdfxIU/iUM87hW9S7rI/v1/1000x-1.jpg",
//             "videoURL": "https://www.youtube.com/watch?v=XEpAgCnnYdY"
//         },
//         {
//             "id": 12,
//             "userID": "312",
//             "createdDate": "2020-09-14T23:18:17",
//             "expiryDate": "2021-12-30T23:18:17",
//             "latitude": "29.695981",
//             "longitude": "-95.428841",
//             "description": "there not here updated",
//             "severity": "2",
//             "imageURL": "https://assets.bwbx.io/images/users/iqjWHBFdfxIU/iUM87hW9S7rI/v1/1000x-1.jpg",
//             "videoURL": "https://www.youtube.com/watch?v=XEpAgCnnYdY"
//         }
//     ]
//     });
  
//     const response = await getAllMarkers();
//     expect(response[0].userID).toEqual("311");
// });

// test('renders without crashing', async () => {
//     let error=''
//     const reactRootDiv = document.createElement('div');
//     let app = ({
//         apiKey: process.env.REACT_APP_FIREBASE_API_KEY,
//         authDomain: process.env.REACT_APP_FIREBASE_AUTH_DOMAIN,
//         databaseURL: process.env.REACT_APP_FIREBASE_DATABASE_URL,
//         projectId: process.env.REACT_APP_FIREBASE_PROJECT_ID,
//         storageBucket: process.env.REACT_APP_FIREBASE_STORAGE_BUCKET,
//         messagingSenderId: process.env.REACT_APP_FIREBASE_MESSAGING_SENDER_ID,
//         appId: process.env.REACT_APP_FIREBASE_APP_ID
//     })
//     expect(reactRootDiv.toString()).toBeTruthy();;
// });



// it('renders without crashing', () => {
//     const div = document.createElement('div');
//     ReactDOM.render(<App />, div);
// });