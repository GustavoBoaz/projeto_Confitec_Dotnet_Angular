const PROXY_CONFIG = [
  {
    context: [
      "/api/Users",
    ],
    target: "https://localhost:5001",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
