```mermaid
classDiagram
  class Flight {
    int Id
    string Code
    string Origin
    string Destination
    DateTime DepartureUtc
    DateTime ArrivalUtc
    int TotalSeats
    FlightStatus Status
    int SeatsAvailable
  }
  class Passenger {
    int Id
    string FullName
    string Document
    string Phone
    string Email
  }
  class Reservation {
    int Id
    int FlightId
    int PassengerId
    string SeatCode
    ReservationStatus Status
    string ReservationCode
    DateTime CreatedUtc
  }
  class TicketHistory {
    int Id
    int ReservationId
    TicketStatus Status
    string Message
    DateTime CreatedUtc
    string FileName
  }
  Flight "1" -- "*" Reservation
  Passenger "1" -- "*" Reservation
  Reservation "1" -- "*" TicketHistory
```

```mermaid
usecaseDiagram
  actor Admin as "Administrador"
  actor User as "Usuario"

  Admin --> (Registrar/Editar Vuelos)
  Admin --> (Cambiar Estado del Vuelo)
  Admin --> (Listar Vuelos)

  User --> (Registrar Pasajero)
  User --> (Editar Pasajero)
  User --> (Listar Pasajeros)

  User --> (Crear Reserva)
  User --> (Cancelar Reserva)
  User --> (Completar Reserva)
  User --> (Generar Ticket PDF)
```
