import '../css/site.css'

import * as Turbo from '@hotwired/turbo'
import { registerControllers } from 'stimulus-vite-helpers'

Turbo.session.drive = true

import './signalRTurboStreamElement'

import { Application } from "@hotwired/stimulus"
const application = Application.start();

const controllers = import.meta.glob('../controllers/**/*_controller.js', { eager: true })
registerControllers(application, controllers)
