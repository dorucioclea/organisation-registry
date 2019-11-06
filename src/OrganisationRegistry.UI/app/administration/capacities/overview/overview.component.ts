import { Component, OnInit } from '@angular/core';

import { AlertService, Alert, AlertType } from 'core/alert';
import { PagedResult, PagedEvent, SortOrder } from 'core/pagination';
import { SearchEvent } from 'core/search';

import {
  Capacity,
  CapacityService,
  CapacityFilter
} from 'services/capacities';

@Component({
  templateUrl: 'overview.template.html',
  styleUrls: [ 'overview.style.css' ]
})
export class CapacityOverviewComponent implements OnInit {
  public isLoading: boolean = true;
  public capacities: PagedResult<Capacity> = new PagedResult<Capacity>();

  private filter: CapacityFilter = new CapacityFilter();
  private currentSortBy: string = 'name';
  private currentSortOrder: SortOrder = SortOrder.Ascending;

  constructor(
    private alertService: AlertService,
    private capacityService: CapacityService) { }

  ngOnInit() {
    this.loadCapacities();
  }

  search(event: SearchEvent<CapacityFilter>) {
    this.filter = event.fields;
    this.loadCapacities();
  }

  changePage(event: PagedEvent) {
    this.currentSortBy = event.sortBy;
    this.currentSortOrder = event.sortOrder;
    this.loadCapacities(event);
  }

  private loadCapacities(event?: PagedEvent) {
    this.isLoading = true;
    let capacities = (event === undefined)
      ? this.capacityService.getCapacities(this.filter, this.currentSortBy, this.currentSortOrder)
      : this.capacityService.getCapacities(this.filter, event.sortBy, event.sortOrder, event.page, event.pageSize);

    capacities
      .finally(() => this.isLoading = false)
      .subscribe(
        newCapacities => this.capacities = newCapacities,
        error => this.alertService.setAlert(
          new Alert(
            AlertType.Error,
            'Hoedanigheden kunnen niet geladen worden!',
            'Er is een fout opgetreden bij het ophalen van de gegevens. Probeer het later opnieuw.')));
  }
}