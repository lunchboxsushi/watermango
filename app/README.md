# app
WaterMango is a run-time service application that does not persist data (no database).
It is primarly used to water plants remotely based on specific criteria

make sure to update host.etc and binding in IIS to use the correct endpoints. The main
glue is fixing the devServer proxy for vlue-cli-service so that the proxy and cors are working 
together nicely

## pre-requisits
(Node.js with NPM)[https://nodejs.org/en/download/]

## Project setup
```
in the current directory run `npm install` in the command line
```

### Compiles and hot-reloads for development
NOTE: for testing/demo purposes just run the command
```
npm run serve 
```

### Compiles and minifies for production
```
npm run build
```

### Run your tests
```
npm run test
```

### Lints and fixes files
```
npm run lint
```