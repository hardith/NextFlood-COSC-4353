import React, { useState } from "react"
// import { Card, Button, Alert } from "react-bootstrap"
import { useAuth } from "../contexts/AuthContext"
import {  useHistory } from "react-router-dom"
import MenuAppBar from "./AppBar"
import MapBox from "./Map"

export default function Dashboard() {
  const [error, setError] = useState("")
  const { currentUser, logout } = useAuth()
  const history = useHistory()

  async function handleLogout() {
    setError("")
    console.log(error)
    console.log(currentUser)
    try {
      await logout()
      history.push("/login")
    } catch {
      setError("Failed to log out")
    }
  }

  const handleUpdateProfile = () => {
    history.push("/update-profile")
  }; 

  return (
    <>
      <div className="row" style={{width:'100%', marginRight:0, marginLeft:0}}>
        <div className="col-sm-12 pl-0 pr-0">
          <MenuAppBar 
            handleLogout={handleLogout} 
            handleUpdateProfile={handleUpdateProfile}
          />
        </div>
        <div className="col-sm-12 pl-0 pr-0">
          <MapBox />
        </div>
      </div>
    </>
  )
}
