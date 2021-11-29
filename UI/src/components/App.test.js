// import { initializeApp } from "firebase";
// import { auth } from "../firebase"

// describe('Firebase Util Test Suite',()=>{
//     beforeAll(async() => {
//         jest.setTimeout(10000);
//         await initializeApp()
//     })

//     beforeEach(async() => {
//         await auth.signOut();
//     })
// })

// test('signInWithEmailAndPassword should throw error with wrong credentials',async () => {
//     let error=''
//     try {
//         await auth.signInWithEmailAndPassword("test", "test")
//     } catch (err) {
//         error = err.toString()
//     }

//     expect(error).toEqual(
//         'Error: The password is invalid or the user does not have a passowrd'
//     )
// })