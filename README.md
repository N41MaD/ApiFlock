# Web Api Flock
NET CORE 5 Web API con Basic Authentication, con MySQL, hosteada en Heroku


# External Service
https://apis.datos.gob.ar/georef/api/provincias


# USO DE LA API
- Usar POSTMAN o SWAGGER


## Ejercicio 1
- url: /Login
- Metodo: POST
- Autenticacion básica
- JSON:
  {
    "email": "mail",
    "password": "Passw2asdaord"
  }
- Simula un login con un único usuario correcto paramétrizado. En caso de login correcto devuelve un Bearer token, caso contrario devuelve un Not Found

## Ejercicio 2
- url: /GetProvinceLocalization/{nombre}
- Metodo: GET
- Autenticacion básica
- Consume una api la cual trae datos de localización de provincias. El endpoint devuelve una lista de provincias en base al nombre enviado.
- JSON:
  {
    "$id": "1",
    "$values": 
    [
      {
        "$id": "2",
        "nombre": "Santa Cruz",
        "latitud": "-48,8154851827063",
        "longitud": "-69,9557621671973"
      },
      {
        "$id": "3",
        "nombre": "Santa Fe",
        "latitud": "-30,7069271588117",
        "longitud": "-60,9498369430241"
      }
    ]
  }
